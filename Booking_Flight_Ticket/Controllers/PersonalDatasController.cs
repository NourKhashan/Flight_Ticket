using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Booking_Flight_Ticket.Models;

namespace Booking_Flight_Ticket.Controllers
{
    public class PersonalDatasController : Controller
    {
        private BookingModel db = new BookingModel();

        [HttpPost]
        public JsonResult IsEmailAlreadySigned(string Email)
        {
            var emailExist = db.PersonalDatas.SingleOrDefault(p=>p.Email.ToLower() == Email.ToLower());

            return Json(emailExist!=null? false: true);

        }

        [HttpPost]
        public JsonResult IsNameAlreadySigned(string LastName, string FirstName, string MiddleName,string GrandFatherName)
        {
            var nameExist = db.PersonalDatas.SingleOrDefault(p => p.LastName.ToLower() == LastName.ToLower() 
                                                          && p.FirstName.ToLower() == FirstName.ToLower() 
                                                          && p.MiddleName.ToLower() == MiddleName.ToLower() 
                                                          && p.GrandFatherName.ToLower() == GrandFatherName.ToLower());
            return Json(nameExist != null ? false : true);

        }

        [HttpPost]
        public JsonResult IsIdenityNumberAlreadySigned(string IdentityNumber)
        {
            var Exist = db.PersonalDatas.SingleOrDefault(p => p.IdentityNumber == IdentityNumber);
            return Json(Exist != null ? false : true);

        }
        // GET: PersonalDatas
        public ActionResult Index()
        {
            return View(db.PersonalDatas.ToList());
        }
        public ActionResult test()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email)
        {
            var exist = db.PersonalDatas.SingleOrDefault(p => p.Email.ToLower() == Email.ToLower());
            if(exist != null)
            {
                TempData["PersonId"] = exist.Id;
                return RedirectToAction("Create", "ReservationDatas");
            }
            return View();

        }

        public ActionResult Choose()
        {
            return View();
        }

        // GET: PersonalDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalData personalData = db.PersonalDatas.Find(id);
            if (personalData == null)
            {
                return HttpNotFound();
            }
            return View(personalData);
        }

        // GET: PersonalDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,MiddleName,GrandFatherName,LastName,Email,IdentityNumber,BirthDate,BithPlace,PhoneNumber,MobileNumber,Residence,Street")] PersonalData personalData)
        {
            if (ModelState.IsValid)
            {
                db.PersonalDatas.Add(personalData);
                db.SaveChanges();
                TempData["PersonId"] = personalData.Id;
                return RedirectToAction("Create", "ReservationDatas");
            }

            return View(personalData);
        }

        // GET: PersonalDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalData personalData = db.PersonalDatas.Find(id);
            if (personalData == null)
            {
                return HttpNotFound();
            }
            return View(personalData);
        }

        // POST: PersonalDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,MiddleName,GrandFatherName,LastName,Email,IdentityNumber,BirthDate,BithPlace,PhoneNumber,MobileNumber,Residence,Street")] PersonalData personalData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personalData);
        }

        // GET: PersonalDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalData personalData = db.PersonalDatas.Find(id);
            if (personalData == null)
            {
                return HttpNotFound();
            }
            return View(personalData);
        }

        // POST: PersonalDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalData personalData = db.PersonalDatas.Find(id);
            db.PersonalDatas.Remove(personalData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

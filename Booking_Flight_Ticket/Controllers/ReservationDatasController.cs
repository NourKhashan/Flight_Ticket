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
    public class ReservationDatasController : Controller
    {
        private BookingModel db = new BookingModel();


        // GET: ReservationDatas
        public ActionResult Index()
        {
            return View(db.ReservationDatas.ToList());
        }
        public ActionResult Finish()
        {
            return View();
        }


        public ActionResult Search(int Adult, int? Childern, DateTime From, DateTime To, int clas)
        {

            if (From == null)
                From = DateTime.Now;
            if (To == null)
                To = DateTime.Now;
            int days = To.Subtract(From).Days;
         
            ViewBag.Days = days;
            ViewBag.From = From;
            ViewBag.To = To;
            return PartialView("_ReservationDays");
        }

        // GET: ReservationDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationData reservationData = db.ReservationDatas.Find(id);
            if (reservationData == null)
            {
                return HttpNotFound();
            }
            return View(reservationData);
        }

        // GET: ReservationDatas/Create
        public ActionResult Create()
        {
            List<SelectListItem> Class = new List<SelectListItem>()
            {

                 new SelectListItem {Text = "Business", Value = "1" },
                 new SelectListItem {Text = "First", Value = "2" },
                 new SelectListItem {Text = "Economy", Value = "3" },

            };
            ViewBag.Class = Class;
            return View();
        }

        // POST: ReservationDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AdultNumber,ChildernNumberNumber,DateFrom,DateTo")] ReservationData reservationData)
        {
            
            if (ModelState.IsValid)
            {

                int row = int.Parse(Request.Form["Row"]);
                int col = int.Parse(Request.Form["Col"]);
                if(row <=0 )
                    return View(reservationData);
                int id = Convert.ToInt32(TempData["PersonId"]);
                reservationData.PersonId = id;
                reservationData.DateFrom = reservationData.DateFrom.AddDays(col-1);
                ViewBag.row = row;
                ViewBag.col = col;
                db.ReservationDatas.Add(reservationData);
                db.SaveChanges();

                return View("Finish", reservationData);
            }

            return View(reservationData);
        }


        // GET: ReservationDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationData reservationData = db.ReservationDatas.Find(id);
            if (reservationData == null)
            {
                return HttpNotFound();
            }
            return View(reservationData);
        }

        // POST: ReservationDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AdultNumber,ChildernNumberNumber,DateFrom,DateTo")] ReservationData reservationData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservationData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservationData);
        }

        // GET: ReservationDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationData reservationData = db.ReservationDatas.Find(id);
            if (reservationData == null)
            {
                return HttpNotFound();
            }
            return View(reservationData);
        }

        // POST: ReservationDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReservationData reservationData = db.ReservationDatas.Find(id);
            db.ReservationDatas.Remove(reservationData);
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

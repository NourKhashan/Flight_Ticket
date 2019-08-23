using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Booking_Flight_Ticket.Models
{
    public class PersonalData
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Must enter char ONLY")]
        [Display(Name = ("First Name"))]
        public string FirstName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Must enter char ONLY")]
        [Display(Name = ("Middle Name"))]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Must enter char ONLY")]
        [Display(Name = ("GrandFather Name"))]
        public string GrandFatherName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z ]*$",ErrorMessage = "Must enter char ONLY")]
        [Remote("IsNameAlreadySigned", "PersonalDatas", AdditionalFields= "FirstName, MiddleName, GrandFatherName", HttpMethod = "POST", ErrorMessage = "Name already exists in database.")]
     
        [Display(Name = ("Last Name"))]
        public string LastName { get; set; }

        [Required, EmailAddress]
        [Remote("IsEmailAlreadySigned", "PersonalDatas", HttpMethod = "POST", ErrorMessage = "Email already exists in database.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^[0-9]{14}$", ErrorMessage = "Must enter 14 Number ONLY")]
        [Display(Name = ("Identity Number"))]
        [Remote("IsIdenityNumberAlreadySigned", "PersonalDatas", HttpMethod = "POST", ErrorMessage = "Idenity Number already exists in database.")]

        public string IdentityNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Must enter char ONLY")]
        [StringLength(10, MinimumLength = 3)]
        public string BithPlace { get; set; }

        [Required]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Phone number Mmst enter 11 Number ONLY")]
        [Display(Name = ("Phone Number"))]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Mobile number must enter 11 Number ONLY")]
        [Display(Name = ("Mobile Number"))]
        public string MobileNumber { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Must enter char ONLY")]
        [StringLength(10, MinimumLength = 3)]
        public string Residence { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_ ]*$", ErrorMessage = "Must enter char or number or _")]

        public string Street { get; set; }
    }
}
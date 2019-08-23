using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Booking_Flight_Ticket.Models
{
    public class ReservationData
    {
        public int Id { get; set; }

        public int Class { get; set; }
        [Required]
        [Display(Name = ("Adult No."))]
        public int AdultNumber { get; set; } = 1;

        [Required]
        [Display(Name = ("Childern No."))]

        public int ChildernNumberNumber { get; set; } = 0;
        [Display(Name = ("Date From"))]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateFrom { get; set; } 

        [Display(Name = ("Date To"))]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateTo { get; set; } 

        [ForeignKey("PersonalData")]
        public int PersonId { get; set; }

    

        public virtual PersonalData PersonalData { get; set; }




    }
}
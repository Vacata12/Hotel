using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class ReservationModel
    {

        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public DateTime ArriveDateTime { get; set; }
        public DateTime DepartureDateTime { get; set; }
        [StringLength(100)]
        public string Room { get; set; }
        public int NumberOfPeople { get; set; }
        [NotMapped]
        public string ArriveDate => ArriveDateTime.ToString("MM/dd/yyyy");
        [NotMapped]
        public string ArriveTime => ArriveDateTime.ToString("hh:mm tt");
        [NotMapped]
        public string DepartureDate => DepartureDateTime.ToString("MM/dd/yyyy");
        [NotMapped]
        public string DepartureTime => DepartureDateTime.ToString("hh:mm tt");
    }
}
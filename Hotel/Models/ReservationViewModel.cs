using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Room { get; set; }
        public int NumberOfPeople { get; set; }
        [Required]
        public string ArriveDate { get; set; }
        [Required]
        public string ArriveTime { get; set; }
        [Required]
        public string DepartureDate { get; set; }
        [Required]
        public string DepartureTime { get; set; }
        public DateTime ArriveDateTime => ArriveTime.Length == 9 ? DateTime.ParseExact($"{ArriveDate} {ArriveTime}", "MM/dd/yyyy h : mm tt", CultureInfo.GetCultureInfo("en-Us")) : DateTime.ParseExact($"{ArriveDate} {ArriveTime}", "MM/dd/yyyy hh : mm tt", CultureInfo.GetCultureInfo("en-US"));
        public DateTime DepartureDateTime => DepartureTime.Length == 9 ? DateTime.ParseExact($"{DepartureDate} {DepartureTime}", "MM/dd/yyyy h : mm tt", CultureInfo.GetCultureInfo("en-Us")): DateTime.ParseExact($"{DepartureDate} {DepartureTime}", "MM/dd/yyyy hh : mm tt", CultureInfo.GetCultureInfo("en-Us"));
    }
}
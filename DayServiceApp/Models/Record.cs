using System;
using System.ComponentModel.DataAnnotations;

namespace DayServiceApp.Models
{
    public class Record
    {
        public int Id { get; set; }

        [Required]
        public string StaffName { get; set; }

        [Required]
        public string Activity { get; set; }

        public DateTime Date { get; set; }
    }
}

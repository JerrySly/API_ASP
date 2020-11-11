using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIApp.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required]
        public string NameOfService { get; set; }
        [Required]
        public double DurationInMinutes { get; set; }
        [Required]
        public double ExpensesForCompany { get; set; }


    }
}

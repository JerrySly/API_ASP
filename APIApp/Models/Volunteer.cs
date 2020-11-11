using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIApp.Models
{

    public class Volunteer:Human
    {
        [Required]
        public int ExpWork { get; set; }
        [Required]
        public string WorkForToday { get; set; }
    }
}

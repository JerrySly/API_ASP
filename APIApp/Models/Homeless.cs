using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIApp.Models
{
    public class Homeless:Human

    {
        [Required]
        public int FullYearsWithoutHome { get; set; }

        public bool Known { get; set; }
    }
}

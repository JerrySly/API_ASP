using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIApp.Models.DOTModels
{
    public class DTOService
    {
        public int Id { get; set; }
        public string NameOfService { get; set; }
        public double DurationInMinutes { get; set; }
    }
}

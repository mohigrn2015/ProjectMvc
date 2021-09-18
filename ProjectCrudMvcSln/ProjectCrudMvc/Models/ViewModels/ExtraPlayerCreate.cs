using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectCrudMvc.Models.ViewModels
{
    public class ExtraPlayerCreate
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string HireInBPL { get; set; }
        public double SigningMoney { get; set; }
    }
}
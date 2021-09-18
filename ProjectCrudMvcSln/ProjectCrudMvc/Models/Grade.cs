using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectCrudMvc.Models
{
    public class Grade
    {       
        public int GradeID { get; set; }
        public string GradeName { get; set; } 
        public virtual ICollection<Player> Players { get; set; }
    }
}

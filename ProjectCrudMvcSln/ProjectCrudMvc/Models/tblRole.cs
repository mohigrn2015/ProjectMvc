using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectCrudMvc.Models
{
    public class tblRole
    {
       
        public int ID { get; set; } 
        public string RoleName { get; set; }
        public int UserID { get; set; }

        public virtual tblUser TblUser { get; set; }
        
    }
}

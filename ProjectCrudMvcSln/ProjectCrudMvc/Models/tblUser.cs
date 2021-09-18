using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectCrudMvc.Models
{
    public class tblUser 
    {
        public tblUser()
        {
            this.tblRoles = new HashSet<tblRole>();
        }
        [Key]
        public int ID { get; set; } 
        [DataType(DataType.EmailAddress)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string UserPassword { get; set; }
        
        public string FullName { get; set; }

        public virtual ICollection<tblRole> tblRoles { get; set; }
        
    }
}

 
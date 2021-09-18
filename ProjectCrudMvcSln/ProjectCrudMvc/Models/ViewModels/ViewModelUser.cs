using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectCrudMvc.Models.ViewModels
{
    public class ViewModelUser
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}
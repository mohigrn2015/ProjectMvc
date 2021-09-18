using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectCrudMvc.Models.ViewModels
{
    public class CustomHireDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            return dateTime <= DateTime.Now;
        }
    }
}
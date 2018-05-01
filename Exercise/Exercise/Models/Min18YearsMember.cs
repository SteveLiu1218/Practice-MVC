using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exercise.Models
{
    public class Min18YearsMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customers)validationContext.ObjectInstance;
            //如果MemberShipTypeId 的Dropdownlist 如果沒選跟選第一個 就會return成功
            // MemberShipType.PayaAsYouGo 其實就只是在ViewModel給的屬性 也可以用 0 1 拉
            if (customer.MemberShipTypeId == MemberShipType.PayaAsYouGo || customer.MemberShipTypeId == MemberShipType.Unknown)
            {
                return ValidationResult.Success;
            }
            //如果前面不是選預設 跟 第一個 就會出現
            if (customer.BirthdayDate == null)
            {
                return new ValidationResult("Birthdate is required.");
            }

            var age = DateTime.Today.Year - customer.BirthdayDate.Value.Year;

            //如果小於18歲又會有不同訊息
            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customers should be 18 years old.");
        }
    }
}
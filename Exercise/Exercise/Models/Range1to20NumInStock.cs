using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exercise.Models
{
    public class Range1to20NumInStock:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            return (movie.NumInStock < 20 && movie.NumInStock > 1)
                    ? ValidationResult.Success
                    : new ValidationResult("Numinstock should be 1 to 20 .");
        }
    }
}
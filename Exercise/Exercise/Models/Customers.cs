using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exercise.Models
{
    public class Customers
    {
        public int Id { get; set; }

        [Required(ErrorMessage="這裡可以更改ErrorMsg顯示再下面的")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MemberShipType MemberShipType { get; set; }

        [Display(Name="MemberShip Type")]
        public byte MemberShipTypeId { get; set; }

        [Display(Name="Date of birthdate")]
        [Min18YearsMember]
        public DateTime? BirthdayDate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exercise.Models;

namespace Exercise.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }
        public Customers Customers { get; set; }
    }
}
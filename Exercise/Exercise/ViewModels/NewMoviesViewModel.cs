using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exercise.Models;

namespace Exercise.ViewModels
{
    public class NewMoviesViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public Movie Movie { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercise.Models
{
    public class Movie
    {   
        public int Id { get; set; }
        public string Name { get; set; }        
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int NumInStock { get; set; }
        public Genre Genres { get; set; }               
        public byte GenreId { get; set; }
    }
}
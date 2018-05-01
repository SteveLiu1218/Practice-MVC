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

        [Required]
        [StringLength(255)]
        public string Name { get; set; }   
     
        //因為?所以變成可以填null
        //但也因為這樣 所以Validation 不會有限制 因為null可以呀...
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range1to20NumInStock]
        [Display(Name= "Number in stock")]
        public int NumInStock { get; set; }

        public Genre Genres { get; set; }    
           
        public byte GenreId { get; set; }
    }
}
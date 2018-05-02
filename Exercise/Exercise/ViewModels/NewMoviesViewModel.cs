using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exercise.Models;
using System.ComponentModel.DataAnnotations;

namespace Exercise.ViewModels
{
    public class NewMoviesViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //因為?所以變成可以填null
        //但也因為這樣 所以Validation 不會有限制 因為null可以呀...
        [Display(Name="Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range1to20NumInStock]
        [Display(Name = "Number in stock")]
        public int NumInStock { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        public string Title
        {
            get
            {
                if (Id != 0)
                {
                    return "Edit Movie";
                }
                return "New Movie";
            }
        }

        public NewMoviesViewModel()
        {

        }

        public NewMoviesViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumInStock = movie.NumInStock;
            GenreId = movie.GenreId;
        }
    }
}
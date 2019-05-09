using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }
        [Display (Name = "Release Date")]
        [Required (ErrorMessage = "The Release Date field is required.")]
        public DateTime? ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }
        [Display (Name = "Number in Stock")]
        [Required (ErrorMessage = "The Number in Stock field is required.")]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20.")]
        public byte? NrInStock { get; set; }
        public byte? NrAvailable { get; set; }
        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        [Required (ErrorMessage = "The Genre field is required.")]
        public byte GenreId { get; set; }


        
    }
}
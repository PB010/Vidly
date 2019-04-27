using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Views.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public Movie Movie { get; set; }

        public string Title
        {
            get
            {
                if (Movie.Name == null && Movie.Id == 0)
                    return "New Movie";

                return "Edit Movie";
            }
        }

    }
}
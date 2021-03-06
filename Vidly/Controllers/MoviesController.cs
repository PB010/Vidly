﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Views.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
            
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }

            return View("ReadOnlyList");
            
        }

        public ActionResult Details(int? id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            return View(movie);
        }

        [Authorize (Roles = RoleName.CanManageMovies)]
        public ActionResult New(Movie movie)
        {
            var genreList = _context.Genres.ToList();
            var movieModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genre = genreList
            };

            return View("MovieForm", movieModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genre = _context.Genres.ToList()
                };
            
                return View("MovieForm", movieModel);
            }

            if (movie.Id == 0)
            {
                movie.NrAvailable = movie.NrInStock;
                _context.Movies.Add(movie);
            }
                
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NrInStock = movie.NrInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [Authorize (Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int? id)
        {
            var movies = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movies == null)
                return HttpNotFound();

            var movieForm = new MovieFormViewModel
            {
                Movie = movies,
                Genre = _context.Genres.ToList()
            };

            return View("MovieForm", movieForm);
        }
    }
}
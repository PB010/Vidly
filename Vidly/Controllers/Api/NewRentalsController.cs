using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Authorize]
    public class NewRentalsController : ApiController
    {

        private readonly ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //api/newRentals

        [HttpGet]
        public IHttpActionResult GetRentals()
        {
            
            return Ok(_context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Movie));
        }

        //api/newRentals/1
        [HttpGet]
        public IHttpActionResult GetRental(int id)
        {
            return Ok(_context.Rentals.Single(r => r.Id == id));
        }

        //api/newRentals

        [HttpPost]
        public IHttpActionResult CreateRentals(NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NrInStock == 0)
                    return BadRequest("This movie is not available.");

                movie.NrAvailable--;
                
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
























































































        //public IHttpActionResult NewRental(NewRentalDto newRental)
        //{
        //    var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);
        //    var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();
        //
        //    foreach (var movie in movies)
        //    {
        //        if (movie.NrInStock == 0)
        //            return BadRequest("Movie is not available");
        //
        //        movie.NrInStock--;
        //
        //        var rental = new Rental
        //        {
        //            Customer = customer,
        //            Movie = movie,
        //            DateRented = DateTime.Now
        //        };
        //
        //        _context.Rentals.Add(rental);
        //    }
        //
        //    _context.SaveChanges();
        //
        //    return Ok();
        //}
    }
}
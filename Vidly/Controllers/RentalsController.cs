using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class RentalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }

        public ActionResult MyRentals()
        {
            var myRental = _context.Rentals.Include(r => r.Movie).ToList();

            return View(myRental);
        }
    }
}
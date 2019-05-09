using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    [Authorize]
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

        public ActionResult Index()
        {
            var myRental = _context.Rentals.Include(r => r.Movie).Include(r => r.Customer);

            return View(myRental);
        }
    }
}
using CarDealer.Infrastructure;
using CarDealer.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using CarDealer.Core.Core.Models;
using Microsoft.AspNetCore.WebUtilities;
using CarDealer.Application.Services;

namespace CarDealer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly CarService _carService;
        public HomeController(ApplicationDbContext context, IConfiguration configuration, CarService carServie)
        {
            _context = context;
            _configuration = configuration;
            _carService = carServie;
        }

        public IActionResult Index(int page = 1)
        {
            int pageSize = 5;
            var totalCars = _context.Cars.Count();
            var cars = _context.Cars
                               .Skip((page - 1) * pageSize)
                               .Take(pageSize)
                               .ToList();

            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCars / pageSize);
            ViewBag.CurrentPage = page;

            return View(cars);
        }

        public async Task<IActionResult> Details(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
                return NotFound();

            return View(car);
        }
        [HttpGet]
        public IActionResult SubmitInquiry(int carId)
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == carId);
            if (car == null)
            {
                TempData["ErrorMessage"] = "Car details could not be found.";
                return RedirectToAction("Index");
            }

            var inquiry = new Inquiry
            {
                CarId = carId,
                Car = car 
            };

            return View(inquiry);
        }

        [HttpPost]
        public IActionResult SubmitInquiry(Inquiry inquiry)
        {
            if (ModelState.IsValid)
            {
                _context.Inquiries.Add(inquiry);
                _context.SaveChanges();

               
                TempData["SuccessMessage"] = "Your inquiry has been submitted successfully!";
                return RedirectToAction("Index");
            }

            return View(inquiry);
        }
    }
}

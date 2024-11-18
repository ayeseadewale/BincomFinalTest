using CarDealer.Application.Services;
using CarDealer.Core.Core.Models;
using CarDealer.Infrastructure;
using CarDealer.Web.Models.Dashboard.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly CarService _carService;
        private readonly ApplicationDbContext _context;
        private readonly ICarServ _carServ;
        private readonly IInquiryServ _inquiryServ;

        public AdminController(CarService carService, ApplicationDbContext context, ICarServ carServ, IInquiryServ inquiryServ)
        {
            _carService = carService;
            _context = context;
            _carServ = carServ;
            _inquiryServ = inquiryServ;
        }

        public IActionResult CarList(int page = 1)
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Car car)
        {
            if (ModelState.IsValid)
            {
                await _carService.AddCarAsync(car);
                return RedirectToAction(nameof(CarList));
            }
            return View(car);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
                return NotFound();
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                await _carService.UpdateCarAsync(car);
                return RedirectToAction(nameof(CarList));
            }
            return View(car);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            if (car == null)
                return NotFound();

            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _carService.DeleteCarAsync(id);
            return RedirectToAction(nameof(CarList));
        }
        public IActionResult ViewInquiriesDetails(int id)
        {
            var inquiry = _context.Inquiries.Include(i => i.Car).FirstOrDefault(i => i.Id == id);
            if (inquiry == null)
                return NotFound();

            return View(inquiry);
        }

        public IActionResult InquiriesList(int page = 1)
        {
            int pageSize = 10;
            var totalInquiries = _context.Inquiries.Include(i => i.Car).Count();
            var inquiries = _context.Inquiries
                                    .Include(i => i.Car)
                                    .Skip((page - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();

            ViewBag.TotalPages = (int)Math.Ceiling((double)totalInquiries / pageSize);
            ViewBag.CurrentPage = page;

            return View(inquiries);
        }

        // Hardcoded admin credentials for simplicity
        private const string AdminUsername = "admin";
        private const string AdminPassword = "password123";

        // GET: Admin/Login
        public IActionResult Index()
        {
            return View();
        }

        // POST: Admin/Login
        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            if (username == AdminUsername && password == AdminPassword)
            {
                // Redirect to the admin dashboard after successful login
                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                // Show an error message if login fails
                TempData["ErrorMessage"] = "Invalid username or password.";
                return View();
            }
        }

        public IActionResult Dashboard(int page = 1, int pageSize = 5)
        {
            var carCount = _context.Cars.Count();
            var inquiryCount = _context.Inquiries.Count();

            var skipAmount = (page - 1) * pageSize;

            var inquiries = _context.Inquiries
                                    .Include(i => i.Car)
                                    .OrderByDescending(i => i.CreatedAt)
                                    .Skip(skipAmount)
                                    .Take(pageSize) 
                                    .ToList();

            var model = new Models.AdminDashboardViewModel
            {
                CarCount = carCount,
                InquiryCount = inquiryCount,
                Inquiries = inquiries,
                CurrentPage = page,
                PageSize = pageSize,
                TotalInquiries = inquiryCount
            };

            return View(model);
        }
    }
}

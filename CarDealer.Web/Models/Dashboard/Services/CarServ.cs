using CarDealer.Infrastructure;
using CarDealer.Web.Models.Dashboard.Interfaces;

namespace CarDealer.Web.Models.Dashboard.Services
{
    public class CarServ:ICarServ
    {
        private readonly ApplicationDbContext _context;

        public CarServ(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetCarCount()
        {
            return _context.Cars.Count();
        }

    }
}

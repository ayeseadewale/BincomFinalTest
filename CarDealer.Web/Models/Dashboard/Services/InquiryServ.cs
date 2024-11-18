using CarDealer.Core.Core.Models;
using CarDealer.Infrastructure;
using CarDealer.Web.Models.Dashboard.Interfaces;

namespace CarDealer.Web.Models.Dashboard.Services
{
    public class InquiryServ:IInquiryServ
    {
        private readonly ApplicationDbContext _context;

        public InquiryServ(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetInquiryCount()
        {
            return _context.Inquiries.Count();
        }

        public List<Inquiry> GetRecentInquiries()
        {
            return _context.Inquiries.OrderByDescending(i => i.CreatedAt).Take(5).ToList();
        }
    }
}

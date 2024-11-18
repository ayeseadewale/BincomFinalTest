using CarDealer.Core.Core.Models;

    namespace CarDealer.Web.Models
    {
    public class AdminDashboardViewModel
    {
        public int CarCount { get; set; }
        public int InquiryCount { get; set; }
        public List<Inquiry> Inquiries { get; set; } = new List<Inquiry>();
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalInquiries { get; set; } // Optional: Total count of inquiries for pagination
    }
}

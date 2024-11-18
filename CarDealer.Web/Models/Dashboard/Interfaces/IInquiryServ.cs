using CarDealer.Core.Core.Models;

namespace CarDealer.Web.Models.Dashboard.Interfaces
{
    public interface IInquiryServ
    {
        int GetInquiryCount();
        List<Inquiry> GetRecentInquiries();
    }
}

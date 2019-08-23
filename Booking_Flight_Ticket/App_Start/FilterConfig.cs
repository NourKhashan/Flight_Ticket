using System.Web;
using System.Web.Mvc;

namespace Booking_Flight_Ticket
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

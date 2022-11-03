using CafeteriaAPI.Models;

namespace CafeteriaAPI.Services
{
    public interface ICashierService
    {
        Invoice CreateInvoice(Sale sale, decimal total);
        Change GetChange(decimal moneyPaid, decimal total);
    }
}

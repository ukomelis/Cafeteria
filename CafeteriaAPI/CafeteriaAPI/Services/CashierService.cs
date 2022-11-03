using CafeteriaAPI.Models;

namespace CafeteriaAPI.Services
{
    public class CashierService : ICashierService
    {
        public CashierService()
        {
            
        }

        public Invoice CreateInvoice(Sale sale, decimal total)
        {
            var invoice = new Invoice
            {
                Total = total,
                MoneyPaid = sale.MoneyPaid,
                Change = GetChange(sale.MoneyPaid, total),
                Sale = sale
            };

            return invoice;
        }
        
        public Change GetChange(decimal moneyPaid, decimal total)
        {
            {
                var change = new Change();
                var denominations = new List<decimal> { 500, 200, 100, 50, 20, 10, 5, 2, 1, 0.5m, 0.2m, 0.1m, 0.05m, 0.02m, 0.01m };
                var changeToReturn = moneyPaid - total;

                change.TotalChange = changeToReturn;

                foreach (var denomination in denominations)
                {
                    var numberOfDenominations = (int)(changeToReturn / denomination);
                    changeToReturn -= numberOfDenominations * denomination;

                    switch (denomination)
                    {
                        case 0.01m:
                            change.OneCent = numberOfDenominations;
                            break;
                        case 0.02m:
                            change.TwoCent = numberOfDenominations;
                            break;
                        case 0.05m:
                            change.FiveCents = numberOfDenominations;
                            break;
                        case 0.1m:
                            change.TenCents = numberOfDenominations;
                            break;
                        case 0.2m:
                            change.TwentyCents = numberOfDenominations;
                            break;
                        case 0.5m:
                            change.FiftyCents = numberOfDenominations;
                            break;
                        case 1:
                            change.One = numberOfDenominations;
                            break;
                        case 2:
                            change.Two = numberOfDenominations;
                            break;
                        case 5:
                            change.Five = numberOfDenominations;
                            break;
                        case 10:
                            change.Ten = numberOfDenominations;
                            break;
                        case 20:
                            change.Twenty = numberOfDenominations;
                            break;
                        case 50:
                            change.Fifty = numberOfDenominations;
                            break;
                        case 100:
                            change.OneHundred = numberOfDenominations;
                            break;
                        case 200:
                            change.TwoHundred = numberOfDenominations;
                            break;
                        case 500:
                            change.FiveHundred = numberOfDenominations;
                            break;
                    }
                }

                return change;
            }
        }

    }
}

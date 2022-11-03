using Autofac.Extras.Moq;
using AutoFixture;
using CafeteriaAPI.Models;
using CafeteriaAPI.Services;

namespace CafeteriaAPI.Tests
{
    [TestFixture]
    public class CashierServiceShould
    {
        private ICashierService _cashierService;
        private AutoMock _autoMock;
        private Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _cashierService = new CashierService();
        }

        [Test]
        [TestCaseSource(nameof(InvoiceTestCases))]
        public void Cashier_Service_Should_Return_Invoice(Sale sale, Invoice excpected, decimal total)
        {
            _autoMock = AutoMock.GetLoose();
            _fixture = new Fixture();

            var change = _autoMock.Create<Change>();
            
            _autoMock.Mock<ICashierService>()
                .Setup(x => x.GetChange(sale.MoneyPaid, total))
                .Returns(change);


            var actual = _cashierService.CreateInvoice(sale, total);

            //TODO fix test
            Assert.NotNull(actual);
            
        }
        
        [Test]
        [TestCaseSource(nameof(ChangeTestCases))]
        public void Cashier_Service_Should_Return_Change(Change excpected, decimal moneyPaid, decimal total)
        {
            var actual = _cashierService.GetChange(moneyPaid, total);

            //TODO fix test
            Assert.That(actual.TotalChange, Is.EqualTo(excpected.TotalChange));
        }

        public static IEnumerable<TestCaseData> ChangeTestCases
        {
            get
            {
                var change1 = new Change
                {
                    TotalChange = 6.98m,
                    OneCent = 1,
                    TwoCent = 1,
                    FiveCents = 1,
                    TenCents = 0,
                    TwentyCents = 2,
                    FiftyCents = 1,
                    One = 1,
                    Two = 0,
                    Five = 1,
                    Ten = 0,
                    Twenty = 0,
                    Fifty = 0,
                    OneHundred = 0,
                    TwoHundred = 0,
                    FiveHundred = 0
                };

                var change2 = new Change
                {
                    TotalChange = 18.99m,
                    OneCent = 0,
                    TwoCent = 2,
                    FiveCents = 1,
                    TenCents = 0,
                    TwentyCents = 2,
                    FiftyCents = 1,
                    One = 1,
                    Two = 1,
                    Five = 1,
                    Ten = 1,
                    Twenty = 0,
                    Fifty = 0,
                    OneHundred = 0,
                    TwoHundred = 0,
                    FiveHundred = 0
                };

                yield return new TestCaseData(change1, 100m, 93.02m);
                yield return new TestCaseData(change2, 50m, 31.01m);
            }
        }

        public static IEnumerable<TestCaseData> InvoiceTestCases
        {
            get
            {
                var sale1 = new Sale
                {
                    MoneyPaid = 100m,
                    ProductOrders = new List<ProductOrder> {
                            new ProductOrder {
                                    ProductId = 1,
                                    ProductName = "Shirt",
                                    Quantity = 2
                                },
                            new ProductOrder
                            {
                                ProductId = 2,
                                ProductName = "Cookie",
                                Quantity = 5
                            }
                        }
                };

                var invoice1 = new Invoice
                {
                    Total = 55m,
                    MoneyPaid = 100m,                    
                    Sale = sale1

                };

                var sale2 = new Sale
                {
                    MoneyPaid = 93.50m,
                    ProductOrders = new List<ProductOrder> {
                            new ProductOrder {
                                    ProductId = 3,
                                    ProductName = "Milk",
                                    Quantity = 2
                                },
                            new ProductOrder
                            {
                                ProductId = 222,
                                ProductName = "Bread",
                                Quantity = 100
                            }
                        }
                };

                var invoice2 = new Invoice
                {
                    Total = 93.02m,
                    MoneyPaid = 93.50m,
                    Sale = sale1

                };


                yield return new TestCaseData(sale1, invoice1, invoice1.Total);
                yield return new TestCaseData(sale2, invoice2, invoice2.Total);
            }
        }
    }
}
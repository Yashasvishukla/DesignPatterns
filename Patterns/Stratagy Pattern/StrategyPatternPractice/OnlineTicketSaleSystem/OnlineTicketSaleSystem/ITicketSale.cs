using OnlineTicketSaleSystem.TaxRateStrategy;
using OnlineTicketSaleSystem.TicketPriceStrategy;

namespace OnlineTicketSaleSystem;

public interface ITicketSale
{
    double CalculateTicketSalePrice(int age);
    void SetTicketPriceStrategy(ITicketPriceStrategy strategy);
    void SetTaxRateStrategy(ITaxRateStrategy taxRateStrategy);
}
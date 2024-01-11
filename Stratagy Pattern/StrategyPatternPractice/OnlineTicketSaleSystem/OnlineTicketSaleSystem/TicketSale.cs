using OnlineTicketSaleSystem.TaxRateStrategy;
using OnlineTicketSaleSystem.TicketPriceStrategy;

namespace OnlineTicketSaleSystem;

public class TicketSale: ITicketSale
{
    private ITicketPriceStrategy _ticketPriceStrategy;
    private ITaxRateStrategy _taxRateStrategy;

    public TicketSale(ITicketPriceStrategy ticketPriceStrategy, ITaxRateStrategy taxRateStrategy)
    {
        _ticketPriceStrategy = ticketPriceStrategy;
        _taxRateStrategy = taxRateStrategy;
    }
    public double CalculateTicketSalePrice(int age)
    {
        var price = _ticketPriceStrategy.CalculateTicketPrice(age);
        var taxPrice = _taxRateStrategy.CalculateTaxRate(price);

        return price + taxPrice;
    }

    public void SetTicketPriceStrategy(ITicketPriceStrategy strategy)
    {
        _ticketPriceStrategy = strategy;
    }

    public void SetTaxRateStrategy(ITaxRateStrategy taxRateStrategy)
    {
        _taxRateStrategy = taxRateStrategy;
    }
}
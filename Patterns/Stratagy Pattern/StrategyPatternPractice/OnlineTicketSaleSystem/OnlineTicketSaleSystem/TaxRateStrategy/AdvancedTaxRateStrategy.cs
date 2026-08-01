namespace OnlineTicketSaleSystem.TaxRateStrategy;

public class AdvancedTaxRateStrategy: ITaxRateStrategy
{
    public double CalculateTaxRate(double price)
    {
        return 0.28 * price;
    }
}
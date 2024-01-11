namespace OnlineTicketSaleSystem.TaxRateStrategy;

public class NormalTaxRateStrategy: ITaxRateStrategy
{
    public double CalculateTaxRate(double price)
    {
        return 0.25 * price;
    }
}
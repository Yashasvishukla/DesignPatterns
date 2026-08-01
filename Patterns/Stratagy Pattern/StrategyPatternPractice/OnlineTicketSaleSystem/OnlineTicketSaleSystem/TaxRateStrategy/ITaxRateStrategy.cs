namespace OnlineTicketSaleSystem.TaxRateStrategy;

public interface ITaxRateStrategy
{
    double CalculateTaxRate(double price);
}
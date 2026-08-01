// See https://aka.ms/new-console-template for more information


using OnlineTicketSaleSystem;
using OnlineTicketSaleSystem.TaxRateStrategy;
using OnlineTicketSaleSystem.TicketPriceStrategy;

try
{
    var ticketSaleAdult = new TicketSale(new AdultTicketPriceStrategy(), new NormalTaxRateStrategy());
    var price = ticketSaleAdult.CalculateTicketSalePrice(50);

    Console.WriteLine($"Normal Ticket Price  {price}");

// Update the behavior at run time 
    ticketSaleAdult.SetTaxRateStrategy(new AdvancedTaxRateStrategy());
    var updatedPrice = ticketSaleAdult.CalculateTicketSalePrice(50);
    Console.WriteLine($"Updated Ticket price  {updatedPrice}");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
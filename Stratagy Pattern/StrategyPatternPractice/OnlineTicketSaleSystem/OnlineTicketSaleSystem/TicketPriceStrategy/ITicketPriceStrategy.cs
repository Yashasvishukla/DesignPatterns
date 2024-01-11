namespace OnlineTicketSaleSystem.TicketPriceStrategy;

public interface ITicketPriceStrategy
{
    double CalculateTicketPrice(int age);
}
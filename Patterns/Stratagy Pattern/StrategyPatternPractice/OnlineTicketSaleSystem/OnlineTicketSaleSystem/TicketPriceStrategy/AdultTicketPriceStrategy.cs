namespace OnlineTicketSaleSystem.TicketPriceStrategy;

public class AdultTicketPriceStrategy: ITicketPriceStrategy
{
    public double CalculateTicketPrice(int age)
    {
        return age is <= 50 and >= 15 ? 15 : throw new ArgumentException("Age must be greater than 15 and less than 50");
    }
}
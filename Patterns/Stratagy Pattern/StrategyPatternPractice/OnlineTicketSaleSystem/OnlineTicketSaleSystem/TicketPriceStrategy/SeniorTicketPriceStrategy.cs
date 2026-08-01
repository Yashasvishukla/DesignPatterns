namespace OnlineTicketSaleSystem.TicketPriceStrategy;

public class SeniorTicketPriceStrategy: ITicketPriceStrategy
{
    public double CalculateTicketPrice(int age)
    {
        return age > 50 ? 12 : throw new AggregateException("Age must be greater than 50");
    }
}
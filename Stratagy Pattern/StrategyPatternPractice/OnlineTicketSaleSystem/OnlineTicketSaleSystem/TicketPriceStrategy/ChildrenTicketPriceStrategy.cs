namespace OnlineTicketSaleSystem.TicketPriceStrategy;

public class ChildrenTicketPriceStrategy: ITicketPriceStrategy
{
    
    public double CalculateTicketPrice(int age)
    {
        return age > 15 ? 10 : throw new ArgumentException("Age must be less than 16");
    }
}
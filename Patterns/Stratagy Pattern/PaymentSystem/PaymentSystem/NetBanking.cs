namespace PaymentSystem;

public class NetBanking: IPaymentMethod
{
    public string  Name { get; set; }
    public string AccountNumber { get; set; }
    
    public double CalculateProcessingFee(double amount)
    {
        return amount * 0.1;
    }
}
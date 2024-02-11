namespace PaymentSystem;

public class DebitCard: IPaymentMethod
{
    public string Name { get; set; }
    public int  Cvv { get; set; }
    public string CardNumber { get; set; }
    
    public double CalculateProcessingFee(double amount)
    {
        return amount * 0.2;
    }
}
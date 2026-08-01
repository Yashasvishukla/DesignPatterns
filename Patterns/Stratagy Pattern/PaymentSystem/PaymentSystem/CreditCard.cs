namespace PaymentSystem;

public class CreditCard: IPaymentMethod
{
    public string CardNumber { get; set; }
    public string Name { get; set; }
    public int Cvv { get; set; }
    
    public double CalculateProcessingFee(double amount)
    {
        return amount * 0.5;
    }
}
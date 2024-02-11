namespace PaymentSystem;

public interface IPaymentMethod
{
    public double CalculateProcessingFee(double amount);
}
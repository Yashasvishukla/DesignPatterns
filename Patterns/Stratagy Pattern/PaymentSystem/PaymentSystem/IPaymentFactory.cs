namespace PaymentSystem;

public interface IPaymentFactory
{
    public IPaymentMethod CreatePaymentMethod(PaymentMode mode);
}
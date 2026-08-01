namespace PaymentSystem;

public class PaymentFactory: IPaymentFactory
{
    public IPaymentMethod CreatePaymentMethod(PaymentMode mode)
    {
        return mode switch
        {
            PaymentMode.DebitCard => new DebitCard(),
            PaymentMode.CreditCard => new CreditCard(),
            PaymentMode.NetBanking => new NetBanking(),
            _ => throw new ArgumentException("Invalid Argument")
        };
    }
}
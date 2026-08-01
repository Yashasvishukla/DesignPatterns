namespace PaymentSystem;

public class PaymentService
{
    private readonly IPaymentFactory _paymentFactory = new PaymentFactory();



    public double CalculateFinalAmount(double amount, PaymentMode mode)
    {
        // The payment service doesn't know about which payment object its working upon
        var payMode = _paymentFactory.CreatePaymentMethod(mode);
        
        
        // it calls for calculating the processing fee
        var processingFee = payMode.CalculateProcessingFee(amount);
        
        // returns the final amount to the user
        return amount + processingFee;
    }
}
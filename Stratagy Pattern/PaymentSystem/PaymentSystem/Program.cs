// See https://aka.ms/new-console-template for more information


using PaymentSystem;

var payment = new PaymentService();
var finalAmount = payment.CalculateFinalAmount(500, PaymentMode.NetBanking);
Console.WriteLine(finalAmount);
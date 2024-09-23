using Stripe;

namespace Emedicine.Services
{
    public class PaymentService : IPaymentService
    {

        private readonly IConfiguration _configuration;
        public PaymentService(IConfiguration config)
        {
            _configuration = config;
        }
        public async Task<string>ProcessCreditCardPaymentAsync(decimal amount, string token)
        {
            var options = new ChargeCreateOptions
            {
                Amount = (long)(amount * 100),
                Currency = "usd",
                Source = token,
                Description = "Payment for product",
            };
            var service = new ChargeService();
            service.ApiKey = _configuration["Stripe:SecretKey"];

            var charge = await service.CreateAsync(options);
            return charge.Id;
        }
        public async Task<string> ProcessBkashPaymentAsync(decimal amount, string PhoneNumber)
        {
            //implement Bkash payment integration here
            //example call bkash api to initiate payment

            return "bkash-transaction-id";
        }
        public async Task<string> ProcessRocketPaymentAsync(decimal amount, string phoneNumber)
        {
            //Implement Rocket payment integration here
            //Example: call Rocket API to initiate payment
            return "rocket-transaction-id";
        }
    }
}

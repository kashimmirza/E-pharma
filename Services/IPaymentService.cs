namespace Emedicine.Services
{
    public interface IPaymentService
    {
        Task<string> ProcessCreditCardPaymentAsync(decimal amount, string token);
        Task<string> ProcessBkashPaymentAsync(decimal amount, string phoneNumber);
        Task<string> ProcessRocketPaymentAsync(decimal amount, string phoneNumber);
    }
}

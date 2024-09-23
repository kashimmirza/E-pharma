namespace Emedicine.Services
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(string phoneNumber, string email);
        Task<bool> VerifyTokenAsync(string token, string phoneNumber, string email);
    }
}

using Emedicine.Models;

namespace Emedicine.Services
{
    public class TokenService :ITokenService
    {

        private readonly IConfiguration _config;
        private readonly Dictionary<string, TokenModel> _token = new();

        public TokenService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<string> GenerateTokenAsync(string PhoneNumber, string email)
        {
            var token = Guid.NewGuid().ToString();
            var expiryDate = DateTime.UtcNow.AddMinutes(10);
            var tokenModel = new TokenModel
            {
                Token = token,
                ExpiryDate = expiryDate,
                PhoneNumber = PhoneNumber,
                Email = email
            };
            _tokens[token]= tokenModel;
            return token;


        }
        public async Task<bool>VerifytokenAsync(string token, string phoneNumber, string email )
        {

            if( _token.TryGetValue(token, out var tokenModel) )
            {
                if(tokenModel.ExpiryDate>DateTime.UtcNow &&
                    (tokenModel.PhoneNumber == phoneNumber || tokenModel.Email == email) )
                {
                    _tokens.Remove(token);
                    return true;
                }
            }
            return false;
        }
    }
}

namespace Emedicine.Models
{

    public class VerifyTokenRequest
    {
        public string Token { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}

namespace Emedicine.Models
{
    public class TokenModel
    {

        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }  
    }
}

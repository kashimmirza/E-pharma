namespace Emedicine.Models
{
    public class Response
    {

        public int statusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<Users>listUsers { get; set; }
        public Users user { get; set; }
        public List<Medicines>listMedicines { get; set; }
        public Medicines medicine { get; set; }
        public List<Cart> listCart { get; set; }
        public List<Orders>listOrders { get; set; }
        public Orders Order { get; set; }
        public List<OrderItems> ItemsInOrder { get; set; }
        public OrderItems OrderItem { get; set; }
        
        
    }
}

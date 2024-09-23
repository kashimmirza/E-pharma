namespace Emedicine.Models
{
    public class OrderItems
    {

        public int ID { get; set; }
        public int OrderID { get; set; }
        public int MedicineID { get; set; }
        public Decimal UnitPrice { get; set; }
        public Decimal Discount { get; set; }
        public int Quantity { get; set; }
        public Decimal TotalPrice { get; set; }
    }
}

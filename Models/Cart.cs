using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Principal;

namespace Emedicine.Models
{
    public class Cart
    {
        public int ID{ get; set; }
        public int UserID { get; set; }
        public int MedicineID {  get; set; }
        public Decimal UnitPrice {get; set;}
        public Decimal Discount { get; set;}
        public int Quantity { get; set;}
        public decimal TotalPrice { get; set;}
        


    }
}

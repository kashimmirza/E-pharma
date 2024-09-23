using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Principal;

namespace Emedicine.Models
{
    public class Orders
    {

        public int ID { get; set; }
        public int UserId  { get; set; }
        public int OrderNo { get; set; }
        public Decimal OrderTotal { get; set; }
        public string OrderStatus { get; set; }

        public Users User { get; set; }



    }
}

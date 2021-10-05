using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
   public class Receipt
    {
        public int ReceiptId { get; set; }
        public int PersonId { get; set; }
        public int GoodId { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal GeneralPrice { get; set; }
        public DateTime BuyTime { get; set; }
    }
}

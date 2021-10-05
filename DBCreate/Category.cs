using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
   public class Category
    {
        public Category()
        {
            this.Good = new HashSet<Good>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Good> Good { get; set; }
    }
}

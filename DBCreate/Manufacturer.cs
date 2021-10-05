using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Good = new HashSet<Good>();
        }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public virtual ICollection<Good> Good { get; set; }
    }
}

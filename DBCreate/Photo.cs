using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Photo
    {

        public Photo()
        {
            this.Good = new HashSet<Good>();
        }
        public int PhotoId { get; set; }
        public string PhotoAddress { get; set; }
        public virtual ICollection<Good> Good { get; set; }
    }
}

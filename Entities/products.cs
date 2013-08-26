using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Entities
{
    public class products : PrestashopEntity
    {
        public long id { get; set; }
        public int quantity { get; set; }
    }
}

using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Entities
{
    public class stock_available : PrestashopEntity
    {
        public int id { get; set; }
        public int id_product_attribute { get; set; }
    }
}
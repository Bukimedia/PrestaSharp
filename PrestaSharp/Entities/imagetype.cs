﻿using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class imagetype : PrestaShopEntity
    {
        public long id { get; set; }
        public string name { get; set; }

        public imagetype()
        {
        }
    }
}
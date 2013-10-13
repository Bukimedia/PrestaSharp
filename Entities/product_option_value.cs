﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestaSharp.Entities
{
    public class product_option_value : PrestashopEntity
    {
        public long? id { get; set; }
        public long? id_attribute_group { get; set; }
        public string color { get; set; }
        public int position { get; set; }
        public List<PrestaSharp.Entities.AuxEntities.language> name { get; set; }
    }
}

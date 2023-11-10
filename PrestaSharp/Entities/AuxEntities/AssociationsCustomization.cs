using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class AssociationsCustomization : PrestaShopEntity
    {
        public List<customized_data_text_field> customized_data_text_fields { get; set; }

        public AssociationsCustomization()
        {
            this.customized_data_text_fields = new List<customized_data_text_field>();
        }

    }
}

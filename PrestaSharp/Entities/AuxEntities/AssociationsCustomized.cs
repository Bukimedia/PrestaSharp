using System.Collections.Generic;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class AssociationsCustomized : PrestaShopEntity
    {
        public List<customized_data_text_field> customized_data_text_fields { get; set; }
        public List<customized_data_image> customized_data_images { get; set; }

        public AssociationsCustomized()
        {
            this.customized_data_text_fields = new List<customized_data_text_field>();
            this.customized_data_images = new List<customized_data_image>();
        }
    }
}
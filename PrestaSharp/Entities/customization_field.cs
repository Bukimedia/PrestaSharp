using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class customization_field : PrestaShopEntity, IPrestaShopFactoryEntity
    {
        public long? id { get; set; }
        
        /// <summary>
        /// Required: Yes
        /// Description: Product ID
        /// </summary>
        public long? id_product { get; set; }

        /// <summary>
        /// Required: Yes
        /// Description: 
        /// For File Value 0
        /// For Text Value 1
        /// </summary>
        public int type { get; set; }
        
        /// <summary>
        /// Required: Yes
        /// It´s a logical bool.
        /// </summary
        public int required { get; set; }
        
        /// <summary>
        /// Required: No
        /// It´s a logical bool.
        /// </summary
        public int is_module { get; set; }
        
        /// <summary>
        /// Required: No
        /// It´s a logical bool.
        /// </summary
        public int is_deleted { get; set; }
        public List<PrestaSharp.Entities.AuxEntities.language> name { get; set; }

        public customization_field()
        {
            this.name = new List<AuxEntities.language>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class snelRunAction : PrestaShopEntity, IPrestaShopFactoryEntity
    {
		//public string customFieldName { get; set; }
		public long? id { get; set; } //needed for class but it's 
		public long? run_id { get; set; }
		public string run_name { get; set; }
		public string date_created { get; set; }
		public string date_launched { get; set; }

		public AuxEntities.AssociationsSnelAction associations { get; set; }

		public snelRunAction()
		{
			this.associations = new AuxEntities.AssociationsSnelAction();
		}
	}

}

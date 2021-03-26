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
	public class snelRunDetail : PrestaShopEntity, IPrestaShopFactoryEntity
	{
		//public string customFieldName { get; set; }


		public long? id { get; set; } // "id" for class but it's  'id_snel_run_order_details'
		public long? id_snel_run_manager { get;set;}
		public long? id_order_detail { get; set; }
		public string added_date { get; set; }

		public snelRunDetail()
		{ 
		
		}
	}

}

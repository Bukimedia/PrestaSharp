using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class snelRunAction : PrestaShopEntity, IPrestaShopFactoryEntity
    {
		public long? id { get; set; } //needed for class but it's 
		public long? id_product { get; set; }
		/// <summary>
		/// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
		/// </summary>
		public string date_created { get; set; }
		/// <summary>
		/// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
		/// </summary>
		public string date_launched { get; set; }

		public AuxEntities.AssociationsSnelAction associations { get; set; }

		public snelRunAction()
		{
			this.associations = new AuxEntities.AssociationsSnelAction();
		}
	}
}
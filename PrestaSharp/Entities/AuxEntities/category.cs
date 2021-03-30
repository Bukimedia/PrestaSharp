using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class category : GenericAssociation
    {
        public category()
            : base()
        {
        }

        public category(long id)
            : base(id)
        {
        }
    }
}

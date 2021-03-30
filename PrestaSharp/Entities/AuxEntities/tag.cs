using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class tag : GenericAssociation
    {
        public tag()
            : base()
        {
        }

        public tag(long id)
            : base(id)
        {
        }
    }
}

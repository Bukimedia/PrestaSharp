using System;
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

        public override bool Equals(object obj)
        {
            PrestaSharp.Entities.product_option_value Aux = (PrestaSharp.Entities.product_option_value)obj;
            bool AreIdAttributeGroupEquals = (this.id_attribute_group == Aux.id_attribute_group);
            bool ContainsLanguage = false;
            for (int i = 0; i < this.name.Count(); i++)
            {
                foreach (PrestaSharp.Entities.AuxEntities.language Language in Aux.name)
                {
                    if (this.name[i].Value == Language.Value)
                    {
                        ContainsLanguage = true;
                    }
                }
            }
            return (AreIdAttributeGroupEquals && ContainsLanguage);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

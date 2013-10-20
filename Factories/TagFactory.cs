using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Factories
{
    public class TagFactory : RestSharpFactory
    {
        public TagFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {

        }

        public Entities.tag Get(long TagId)
        {
            RestRequest request = this.RequestForGet("tags", TagId, "tag");
            return this.Execute<Entities.tag>(request);
        }

        public Entities.tag Add(Entities.tag Tag)
        {
            Tag.id = null;
            RestRequest request = this.RequestForAdd("tags", Tag);
            /*
             * Bug in the serializer with the serialization of id_lang.
             * It´s needed to write again the value of id_lang with the same value of the object Tag.
             */
            Entities.tag aux = this.Execute<Entities.tag>(request);
            aux.id_lang = Tag.id_lang;
            return aux;
        }


        public void Update(Entities.tag Tag)
        {
            RestRequest request = this.RequestForUpdate("tags", Tag.id, Tag);
            this.Execute<Entities.tag>(request);
        }

        public void Delete(Entities.tag Tag)
        {
            RestRequest request = this.RequestForDelete("tags", Tag.id);
            this.Execute<Entities.tag>(request);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("tags", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "tag");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.tag> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("tags", "full", Filter, Sort, Limit, "tags");
            return this.Execute<List<Entities.tag>>(request);
        }

        /// <summary>
        /// Get all tags.
        /// </summary>
        /// <returns>A list of tags</returns>
        public List<Entities.tag> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
    }
}

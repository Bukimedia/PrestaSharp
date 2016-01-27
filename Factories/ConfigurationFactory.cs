using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ConfigurationFactory : RestSharpFactory
    {
        public ConfigurationFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.configuration Get(long ConfigurationId)
        {
            RestRequest request = this.RequestForGet("configurations", ConfigurationId, "configuration");
            return this.Execute<Entities.configuration>(request);
        }

        public Entities.configuration Add(Entities.configuration Configuration)
        {
            long? idAux = Configuration.id;
            Configuration.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(Configuration);
            RestRequest request = this.RequestForAdd("configurations", Entities);
            Entities.configuration aux = this.Execute<Entities.configuration>(request);
            Configuration.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.configuration Configuration)
        {
            RestRequest request = this.RequestForUpdate("configurations", Configuration.id, Configuration);
            this.Execute<Entities.configuration>(request);
        }

        public void Delete(long ConfigurationId)
        {
            RestRequest request = this.RequestForDelete("configurations", ConfigurationId);
            this.Execute<Entities.configuration>(request);
        }

        public void Delete(Entities.configuration Configuration)
        {
            this.Delete((long)Configuration.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("configurations", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "configuration");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.configuration> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("configurations", "full", Filter, Sort, Limit, "configurations");
            return this.ExecuteForFilter<List<Entities.configuration>>(request);
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<long> GetIdsByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("configurations", "[id]", Filter, Sort, Limit, "configurations");
            List<PrestaSharp.Entities.FilterEntities.configuration> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.configuration>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all languages.
        /// </summary>
        /// <returns>A list of languages</returns>
        public List<Entities.configuration> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }

        /// <summary>
        /// Add a list of languages.
        /// </summary>
        /// <param name="Configurations"></param>
        /// <returns></returns>
        public List<Entities.configuration> AddList(List<Entities.configuration> Configurations)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.configuration Configuration in Configurations)
            {
                Configuration.id = null;
                Entities.Add(Configuration);
            }
            RestRequest request = this.RequestForAdd("configurations", Entities);
            return this.Execute<List<Entities.configuration>>(request);
        }
    }
}

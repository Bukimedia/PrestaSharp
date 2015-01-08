using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class TaxRuleFactory : RestSharpFactory
    {
        public TaxRuleFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.tax_rule Get(long TaxRuleId)
        {
            RestRequest request = this.RequestForGet("tax_rules", TaxRuleId, "tax_rule");
            return this.Execute<Entities.tax_rule>(request);
        }

        public Entities.tax_rule Add(Entities.tax_rule TaxRule)
        {
            long? idAux = TaxRule.id;
            TaxRule.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(TaxRule);
            RestRequest request = this.RequestForAdd("tax_rules", Entities);
            Entities.tax_rule aux = this.Execute<Entities.tax_rule>(request);
            TaxRule.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.tax_rule TaxRule)
        {
            RestRequest request = this.RequestForUpdate("tax_rules", TaxRule.id, TaxRule);
            this.Execute<Entities.tax_rule>(request);
        }

        public void Delete(long TaxRuleId)
        {
            RestRequest request = this.RequestForDelete("tax_rules", TaxRuleId);
            this.Execute<Entities.tax_rule>(request);
        }

        public void Delete(Entities.tax_rule TaxRule)
        {
            this.Delete((long)TaxRule.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("tax_rules", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "tax_rule");
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.tax_rule> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("tax_rules", "full", Filter, Sort, Limit, "tax_rules");
            return this.ExecuteForFilter<List<Entities.tax_rule>>(request);
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
            RestRequest request = this.RequestForFilter("tax_rules", "[id]", Filter, Sort, Limit, "tax_rules");
            List<PrestaSharp.Entities.FilterEntities.tax_rule> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.tax_rule>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all tax_rules.
        /// </summary>
        /// <returns>A list of tax_rules</returns>
        public List<Entities.tax_rule> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
        
        /// <summary>
        /// Add a list of tax_rules.
        /// </summary>
        /// <param name="TaxRules"></param>
        /// <returns></returns>
        public List<Entities.tax_rule> AddList(List<Entities.tax_rule> TaxRules)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.tax_rule TaxRule in TaxRules)
            {
                TaxRule.id = null;
                Entities.Add(TaxRule);
            }
            RestRequest request = this.RequestForAdd("tax_rules", Entities);
            return this.Execute<List<Entities.tax_rule>>(request);
        }        
    }
}

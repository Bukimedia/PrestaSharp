using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class TaxRuleGroupFactory : RestSharpFactory
    {
        public TaxRuleGroupFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        public Entities.tax_rule_group Get(long TaxRuleGroupId)
        {
            RestRequest request = this.RequestForGet("tax_rule_groups", TaxRuleGroupId, "tax_rule_group");
            return this.Execute<Entities.tax_rule_group>(request);
        }

        public Entities.tax_rule_group Add(Entities.tax_rule_group TaxRuleGroup)
        {
            long? idAux = TaxRuleGroup.id;
            TaxRuleGroup.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(TaxRuleGroup);
            RestRequest request = this.RequestForAdd("tax_rule_groups", Entities);
            Entities.tax_rule_group aux = this.Execute<Entities.tax_rule_group>(request);
            TaxRuleGroup.id = idAux;
            return this.Get((long)aux.id);
        }

        public void Update(Entities.tax_rule_group TaxRuleGroup)
        {
            RestRequest request = this.RequestForUpdate("tax_rule_groups", TaxRuleGroup.id, TaxRuleGroup);
            this.Execute<Entities.tax_rule_group>(request);
        }

        public void Delete(long TaxRuleGroupId)
        {
            RestRequest request = this.RequestForDelete("tax_rule_groups", TaxRuleGroupId);
            this.Execute<Entities.tax_rule_group>(request);
        }

        public void Delete(Entities.tax_rule_group TaxRuleGroup)
        {
            this.Delete((long)TaxRuleGroup.id);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("tax_rule_groups", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "tax_rule_group");
        }
        
        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.tax_rule_group> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("tax_rule_groups", "full", Filter, Sort, Limit, "tax_rule_groups");
            return this.ExecuteForFilter<List<Entities.tax_rule_group>>(request);
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
            RestRequest request = this.RequestForFilter("tax_rule_groups", "[id]", Filter, Sort, Limit, "tax_rule_groups");
            List<PrestaSharp.Entities.FilterEntities.tax_rule_group> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.tax_rule_group>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }

        /// <summary>
        /// Get all tax_rule_groups.
        /// </summary>
        /// <returns>A list of tax_rule_groups</returns>
        public List<Entities.tax_rule_group> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
        
        /// <summary>
        /// Add a list of tax_rule_groups.
        /// </summary>
        /// <param name="TaxRuleGroups"></param>
        /// <returns></returns>
        public List<Entities.tax_rule_group> AddList(List<Entities.tax_rule_group> TaxRuleGroups)
        {
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new List<PrestaSharp.Entities.PrestaShopEntity>();
            foreach (Entities.tax_rule_group TaxRuleGroup in TaxRuleGroups)
            {
                TaxRuleGroup.id = null;
                Entities.Add(TaxRuleGroup);
            }
            RestRequest request = this.RequestForAdd("tax_rule_groups", Entities);
            return this.Execute<List<Entities.tax_rule_group>>(request);
        }        
    }
}

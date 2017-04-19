using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukimedia.PrestaSharp.Factories
{
    public class EmployeeFactory : RestSharpFactory
    {
        public EmployeeFactory(string BaseUrl, string Account, string SecretKey) : base(BaseUrl, Account, SecretKey)
        {

        }

        public Entities.employee Get(long EmployeId)
        {
            RestRequest request = this.RequestForGet("employees", EmployeId, "employee");
            return this.Execute<Entities.employee>(request);
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.employee> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("employees", "full", Filter, Sort, Limit, "employees");
            return this.ExecuteForFilter<List<Entities.employee>>(request);
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
            RestRequest request = this.RequestForFilter("employees", "[id]", Filter, Sort, Limit, "employees");
            List<PrestaSharp.Entities.FilterEntities.employee> aux = this.Execute<List<PrestaSharp.Entities.FilterEntities.employee>>(request);
            return (List<long>)(from t in aux select t.id).ToList<long>();
        }



        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>A list of products</returns>
        public List<Entities.employee> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
    }
}

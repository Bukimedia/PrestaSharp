﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PrestaSharp.Factories
{
    public class LanguageFactory : RestSharpFactory
    {
        public LanguageFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {

        }

        public Entities.language Get(long LanguageId)
        {
            RestRequest request = this.RequestForGet("languages", LanguageId, "language");
            return this.Execute<Entities.language>(request);
        }

        public Entities.language Add(Entities.language Language)
        {
            Language.id = null;
            RestRequest request = this.RequestForAdd("languages", Language);
            return this.Execute<Entities.language>(request);
        }


        public void Update(Entities.language Language)
        {
            RestRequest request = this.RequestForUpdate("languages", Language.id, Language);
            this.Execute<Entities.language>(request);
        }

        public void Delete(Entities.language Language)
        {
            RestRequest request = this.RequestForDelete("languages", Language.id);
            this.Execute<Entities.language>(request);
        }

        public List<long> GetIds()
        {
            RestRequest request = this.RequestForGet("languages", null, "prestashop");
            return this.ExecuteForGetIds<List<long>>(request, "language");
        }

        /// <summary>
        /// More information about filtering: http://doc.prestashop.com/display/PS14/Chapter+8+-+Advanced+Use
        /// </summary>
        /// <param name="Filter">Example: key:name value:Apple</param>
        /// <param name="Sort">Field_ASC or Field_DESC. Example: name_ASC or name_DESC</param>
        /// <param name="Limit">Example: 5 limit to 5. 9,5 Only include the first 5 elements starting from the 10th element.</param>
        /// <returns></returns>
        public List<Entities.language> GetByFilter(Dictionary<string, string> Filter, string Sort, string Limit)
        {
            RestRequest request = this.RequestForFilter("languages", "full", Filter, Sort, Limit, "languages");
            return this.Execute<List<Entities.language>>(request);
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
            RestRequest request = this.RequestForFilter("languages", "[id]", Filter, Sort, Limit, "languages");
            return this.Execute<List<long>>(request);
        }

        /// <summary>
        /// Get all languages.
        /// </summary>
        /// <returns>A list of languages</returns>
        public List<Entities.language> GetAll()
        {
            return this.GetByFilter(null, null, null);
        }
    }
}
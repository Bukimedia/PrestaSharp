using System;
using System.Collections.Generic;
using System.Linq;

namespace Bukimedia.PrestaSharp.Factories
{
    /// <summary>
    /// Class to be user ine Fcatory method GetByFilter
    /// </summary>
    public class FilterFactory
    {

        /// <summary>
        /// Data sort type
        /// </summary>
        public enum SortType
        {
            ASC,
            DESC
        }

        /// <summary>
        /// Example: key:name value:Apple
        /// </summary>
        public Dictionary<string, string> Filter = new Dictionary<string, string>();

        /// <summary>
        /// Stack of Sort
        /// </summary>
        public Dictionary<string, SortType> SortStack = new Dictionary<string, SortType>();

        /// <summary>
        /// Field_ASC or Field_DESC. Example: name_ASC or name_DESC
        /// For set Use SetSort(field, ordertype)
        /// </summary>
        public string Sort
        {
            get
            {
                if (SortStack.Count == 0) { return ""; }

                string str = "[";
                foreach (KeyValuePair<string, SortType> r in SortStack)
                {
                    str += r.Key + "_" + r.Value.ToString() + ",";
                }
                str = str.Remove(str.Length - 1); ;
                str += "]";
                return str;
            }
        }

        /// <summary>
        /// Example: 
        /// 5 limit to 5. 
        /// 9,5 Only include the first 5 elements starting from the 10th element.
        /// </summary>
        public string Limit;

        /// <summary>
        /// Fields to display Example: ["id", "reference"]
        /// </summary>
        public List<string> Display = new List<string>();

        /// <summary>
        /// Class to be user ine Fcatory method GetByFilter
        /// </summary>
        public FilterFactory()
        {

        }

        /// <summary>
        /// Class to be user ine Fcatory method GetByFilter
        /// Example: key:name value:Apple
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public FilterFactory(string key, string value)
        {
            this.Filter.Add(key, value);
        }

        /// <summary>
        /// Example: key:name value:Apple
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public FilterFactory AddFilter(string key, string value)
        {
            this.Filter.Add(key, value);
            return this;
        }
        
        /// <summary>
         /// Example: key:name value:1
         /// </summary>
         /// <param name="key"></param>
         /// <param name="value"></param>
         /// <returns></returns>
        public FilterFactory AddFilter(string key, int value)
        {
            this.AddFilter(key, value.ToString());
            return this;
        }

        /// <summary>
        /// Example: key:name value:2
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public FilterFactory AddFilter(string key, long value)
        {
            this.AddFilter(key, value.ToString());
            return this;
        }

        /// <summary>
        /// Filter values that starts by value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public FilterFactory AddFilterStarts(string key, string value)
        {
            this.Filter.Add(key, "[" + value + "]%");
            return this;
        }

        /// <summary>
        /// Filter values that ends by value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public FilterFactory AddFilterEnds(string key, string value)
        {
            this.Filter.Add(key, "%[" + value + "]");
            return this;
        }

        /// <summary>
        /// Filter values that ends by value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public FilterFactory AddFilterContains(string key, string value)
        {
            this.Filter.Add(key, "%[" + value + "]%");
            return this;
        }

        /// <summary>
        /// Filter values that ends by value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public FilterFactory AddFilterMultipleValues(string key, List<string> value)
        {
            this.Filter.Add(key, "[" + string.Join("|", value) + "]");
            return this;
        }

        /// <summary>
        /// Filter values that between start an end
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public FilterFactory AddFilterBetween(string key, string start, string end)
        {
            this.Filter.Add(key, "[" + start + "," + end + "]");
            return this;
        }

        /// <summary>
        /// Fields to display Example: ["id", "reference"]
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public FilterFactory AddDisplay(string name)
        {
            this.Display.Add(name);
            return this;
        }

        /// <summary>
        /// Data order type
        /// </summary>
        /// <param name="field"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public FilterFactory AddSort(string field, SortType type)
        {
            this.SortStack.Add(field, type);
            return this;
        }

        /// <summary>
        /// Limit of data fetched
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public FilterFactory SetLimit(int limit, int offset = 0)
        {
            this.Limit = offset.ToString() + "," + limit.ToString();
            return this;
        }

        /// <summary>
        /// Convert to a string the field list to disply 
        /// </summary>
        /// <param name="display"></param>
        /// <returns></returns>
        public static string DispalyToString(List<string> display)
        {
            string disp = "full";
            if (display.Count() >= 1)
            {
                disp = "[";
                display.ForEach(d => { disp += d + ","; });
                disp = disp.Remove(disp.Length - 1); ;
                disp += "]";
            }
            return disp;
        }

    }
}

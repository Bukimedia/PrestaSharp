﻿using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class message : PrestaShopEntity, IPrestaShopFactoryEntity
    {
        public long? id { get; set; }
        public long? id_cart { get; set; }
        public long? id_order { get; set; }
        public long? id_customer { get; set; }
        public long? id_employee { get; set; }
        [XmlElement(ElementName = "message")]
        public string Message { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        [XmlElement(ElementName = "private")]
        public int Private { get; set; }

        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_add { get; set; }

        public message()
        {
        }
    }
}
namespace Bukimedia.PrestaSharp.Entities
{
    public class warehouse_product_location : PrestaShopEntity, IPrestaShopFactoryEntity
    {
        public long? id { get; set; }
        public long? id_product { get; set; }
        public long? id_product_attribute { get; set; }
        public long id_warehouse { get; set; }
        public string location { get; set; }
    }
}

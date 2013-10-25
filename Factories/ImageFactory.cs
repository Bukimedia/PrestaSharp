using PrestaSharp.Factories;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestaSharp.Factories
{
    public class ImageFactory : RestSharpFactory
    {
        public ImageFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {

        }

        #region Protected methods

        protected List<Entities.image> GetAllImages(string Resource){
            RestRequest request = this.RequestForFilter("images/" + Resource, "full", null, null, null, "images");
            return this.Execute<List<Entities.image>>(request);
        }

        protected void AddImage(string Resource, long? Id, string ImagePath)
        {
            RestRequest request = this.RequestForAddImage(Resource, Id, ImagePath);
            this.Execute<Entities.image>(request);
        }

        protected void UpdateImage(string Resource, long? Id, string ImagePath)
        {
            this.DeleteImage(Resource, Id);
            this.AddImage(Resource, Id, ImagePath);
        }

        protected void DeleteImage(string Resource, long? Id)
        {
            RestRequest request = this.RequestForDeleteImage(Resource, Id);
            this.Execute<Entities.image>(request);
        }

        #endregion Protected methods

        #region Manufacturer images

        public List<Entities.image> GetAllManufacturerImages()
        {
            return this.GetAllImages("manufacturers");
        }

        public void AddManufacturerImage(long ManufacturerId, string ManufacturerImagePath)
        {
            this.AddImage("manufacturers", ManufacturerId, ManufacturerImagePath);
        }

        public void UpdateManufacturerImage(long ManufacturerId, string ManufacturerImagePath)
        {
            this.UpdateImage("manufacturers", ManufacturerId, ManufacturerImagePath);
        }

        public void DeleteManufacturerImage(long ManufacturerID)
        {
            this.DeleteImage("manufacturers", ManufacturerID);
        }

        #endregion Manufacturer images

        #region Product images

        public List<Entities.image> GetAllProductImages()
        {
            return this.GetAllImages("products");
        }

        public void AddProductImage(long ProductId, string ProductImagePath)
        {
            this.AddImage("products", ProductId, ProductImagePath);
        }

        public void UpdateProductImage(long ProductId, string ProductImagePath)
        {
            this.UpdateImage("products", ProductId, ProductImagePath);
        }

        public void DeleteProductImage(long? ProductId)
        {
            this.DeleteImage("products", ProductId);
        }

        #endregion Product images

        #region Category images

        public List<Entities.image> GetAllCategoryImages()
        {
            return this.GetAllImages("categories");
        }

        public void AddCategoryImage(long? CategoryId, string CategoryImagePath)
        {
            this.AddImage("categories", CategoryId, CategoryImagePath);
        }

        public void UpdateCategoryImage(long CategoryId, string CategoryImagePath)
        {
            this.UpdateImage("categories", CategoryId, CategoryImagePath);
        }

        public void DeleteCategoryImage(long CategoryID)
        {
            this.DeleteImage("categories", CategoryID);
        }

        #endregion Category images

    }
}

using Bukimedia.PrestaSharp.Factories;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bukimedia.PrestaSharp.Factories
{
    public class ImageFactory : RestSharpFactory
    {
        public ImageFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
        }

        #region Protected methods

        protected List<Entities.image> GetAllImages(string Resource)
        {
            RestRequest request = RequestForFilter("images/" + Resource, "full", null, null, null, "images");
            return Execute<List<Entities.image>>(request);
        }

        protected List<Entities.imagetype> GetAllImageTypes(string Resource)
        {
            RestRequest request = RequestForFilter("images/" + Resource, "full", null, null, null, "image_types");
            return Execute<List<Entities.imagetype>>(request);
        }

        protected List<Entities.FilterEntities.declination> GetImagesByInstance(string Resource, long Id)
        {
            RestRequest request =
                RequestForFilter("images/" + Resource + "/" + Id, "full", null, null, null, "image");
            List<Entities.FilterEntities.declination> Declinations =
                Execute<List<Entities.FilterEntities.declination>>(request);
            List<Entities.FilterEntities.declination> AuxDeclinations = new List<Entities.FilterEntities.declination>();
            foreach (Entities.FilterEntities.declination Declination in Declinations)
            {
                if (!AuxDeclinations.Contains(Declination))
                {
                    AuxDeclinations.Add(Declination);
                }
            }

            return AuxDeclinations;
        }

        protected void AddImage(string Resource, long? Id, string ImagePath)
        {
            RestRequest request = RequestForAddImage(Resource, Id, ImagePath);
            ExecuteForImage(request);
        }

        protected void AddImage(string Resource, long? Id, byte[] Image)
        {
            RestRequest request = RequestForAddImage(Resource, Id, Image);
            ExecuteForImage(request);
        }

        protected void UpdateImage(string Resource, long? ResourceId, long? ImageId, string ImagePath)
        {
            DeleteImage(Resource, ResourceId, ImageId);
            AddImage(Resource, ResourceId, ImagePath);
        }

        protected void UpdateImage(string Resource, long? ResourceId, long? ImageId, byte[] Image)
        {
            DeleteImage(Resource, ResourceId, ImageId);
            AddImage(Resource, ResourceId, Image);
        }

        protected void DeleteImage(string Resource, long? ResourceId, long? ImageId)
        {
            RestRequest request = RequestForDeleteImage(Resource, ResourceId, ImageId);
            Execute<Entities.image>(request);
        }

        #endregion Protected methods

        #region Manufacturer images

        public List<Entities.image> GetAllManufacturerImages()
        {
            return GetAllImages("manufacturers");
        }

        public List<Entities.imagetype> GetAllManufacturerImageTypes()
        {
            return GetAllImageTypes("manufacturers");
        }

        public void AddManufacturerImage(long ManufacturerId, string ManufacturerImagePath)
        {
            AddImage("manufacturers", ManufacturerId, ManufacturerImagePath);
        }

        public void AddManufacturerImage(long ManufacturerId, byte[] ManufacturerImage)
        {
            AddImage("manufacturers", ManufacturerId, ManufacturerImage);
        }

        public void UpdateManufacturerImage(long ManufacturerId, string ManufacturerImagePath)
        {
            UpdateImage("manufacturers", ManufacturerId, null, ManufacturerImagePath);
        }

        public void UpdateManufacturerImage(long ManufacturerId, byte[] ManufacturerImage)
        {
            UpdateImage("manufacturers", ManufacturerId, null, ManufacturerImage);
        }

        public void DeleteManufacturerImage(long ManufacturerId)
        {
            DeleteImage("manufacturers", ManufacturerId, null);
        }

        public byte[] GetManufacturerImage(long ManufacturerId, long ImageId)
        {
            RestRequest request = RequestForGet("images/manufacturers/" + ManufacturerId, ImageId, "");
            return ExecuteForImage(request);
        }

        #endregion Manufacturer images

        #region Product images

        public List<Entities.image> GetAllProductImages()
        {
            return GetAllImages("products");
        }

        public List<Entities.imagetype> GetAllProductImageTypes()
        {
            return GetAllImageTypes("products");
        }

        public List<Entities.FilterEntities.declination> GetProductImages(long ProductId)
        {
            return GetImagesByInstance("products", ProductId);
        }

        public long AddProductImage(long ProductId, string ProductImagePath)
        {
            long r = 0;
            List<Entities.FilterEntities.declination> dif, pre, post;
            try
            {
                pre = GetProductImages(ProductId);
            }
            catch
            {
                // No images...
                pre = new List<Entities.FilterEntities.declination>();
            }

            AddImage("products", ProductId, ProductImagePath);

            post = GetProductImages(ProductId);

            dif = post.Except(pre, new Helpers.CompareDeclination()).ToList();
            if (dif.Count > 0) r = dif[0].id;

            return r;
        }

        public long AddProductImage(long ProductId, byte[] ProductImage)
        {
            long r = 0;
            List<Entities.FilterEntities.declination> dif, pre, post;
            try
            {
                pre = GetProductImages(ProductId);
            }
            catch
            {
                // No images...
                pre = new List<Entities.FilterEntities.declination>();
            }

            AddImage("products", ProductId, ProductImage);

            post = GetProductImages(ProductId);

            dif = post.Except(pre, new Helpers.CompareDeclination()).ToList();
            if (dif.Count > 0) r = dif[0].id;
            return r;
        }

        public void UpdateProductImage(long ProductId, long ImageId, string ProductImagePath)
        {
            UpdateImage("products", ProductId, ImageId, ProductImagePath);
        }

        public void UpdateProductImage(long ProductId, long ImageId, byte[] ProductImage)
        {
            UpdateImage("products", ProductId, ImageId, ProductImage);
        }

        public void DeleteProductImage(long ProductId, long ImageId)
        {
            DeleteImage("products", ProductId, ImageId);
        }

        public byte[] GetProductImage(long ProductId, long ImageId)
        {
            RestRequest request = RequestForGet("images/products/" + ProductId, ImageId, "");
            return ExecuteForImage(request);
        }

        #endregion Product images

        #region Category images

        public List<Entities.image> GetAllCategoryImages()
        {
            return GetAllImages("categories");
        }

        public List<Entities.imagetype> GetAllCategoryImageTypes()
        {
            return GetAllImageTypes("categories");
        }

        public void AddCategoryImage(long? CategoryId, string CategoryImagePath)
        {
            AddImage("categories", CategoryId, CategoryImagePath);
        }

        public void AddCategoryImage(long? CategoryId, byte[] CategoryImage)
        {
            AddImage("categories", CategoryId, CategoryImage);
        }

        public void UpdateCategoryImage(long CategoryId, string CategoryImagePath)
        {
            UpdateImage("categories", CategoryId, null, CategoryImagePath);
        }

        public void UpdateCategoryImage(long CategoryId, byte[] CategoryImage)
        {
            UpdateImage("categories", CategoryId, null, CategoryImage);
        }

        public void DeleteCategoryImage(long CategoryID)
        {
            DeleteImage("categories", CategoryID, null);
        }

        public byte[] GetCategoryImage(long CategoryId, long ImageId)
        {
            RestRequest request = RequestForGet("images/categories/" + CategoryId, ImageId, "");
            return ExecuteForImage(request);
        }

        public byte[] GetCategoryImage(long CategoryId, string TypeName)
        {
            RestRequest request = RequestForGetType("images/categories/" + CategoryId, TypeName, "");
            return ExecuteForImage(request);
        }

        #endregion Category images
    }
}
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

        protected List<Entities.image> GetAllImages(string Resource){
            RestRequest request = this.RequestForFilter("images/" + Resource, "full", null, null, null, "images");
            return this.Execute<List<Entities.image>>(request);
        }

        protected List<Entities.imagetype> GetAllImageTypes(string Resource)
        {
            RestRequest request = this.RequestForFilter("images/" + Resource, "full", null, null, null, "image_types");
            return this.Execute<List<Entities.imagetype>>(request);
        }

        protected List<Entities.FilterEntities.declination> GetImagesByInstance(string Resource, long Id)
        {
            RestRequest request = this.RequestForFilter("images/" + Resource + "/" + Id, "full", null, null, null, "image");
            List<Entities.FilterEntities.declination> Declinations = this.Execute<List<Entities.FilterEntities.declination>>(request);
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
            RestRequest request = this.RequestForAddImage(Resource, Id, ImagePath);
            this.ExecuteForImage(request);
        }
        
        protected void AddImage(string Resource, long? Id, byte[] Image)
        {
            RestRequest request = this.RequestForAddImage(Resource, Id, Image);
            this.ExecuteForImage(request);
        }

        protected void UpdateImage(string Resource, long? ResourceId, long? ImageId, string ImagePath)
        {
            this.DeleteImage(Resource, ResourceId,ImageId);
            this.AddImage(Resource, ResourceId, ImagePath);
        }

        protected void UpdateImage(string Resource, long? ResourceId, long? ImageId, byte[] Image)
        {
            this.DeleteImage(Resource, ResourceId, ImageId);
            this.AddImage(Resource, ResourceId, Image);
        }

        protected void DeleteImage(string Resource, long? ResourceId, long? ImageId)
        {
            RestRequest request = this.RequestForDeleteImage(Resource, ResourceId, ImageId);
            this.Execute<Entities.image>(request);
        }

        #endregion Protected methods

        #region Manufacturer images

        public List<Entities.image> GetAllManufacturerImages()
        {
            return this.GetAllImages("manufacturers");
        }
        public List<Entities.imagetype> GetAllManufacturerImageTypes()
        {
            return this.GetAllImageTypes("manufacturers");
        }

        public void AddManufacturerImage(long ManufacturerId, string ManufacturerImagePath)
        {
            this.AddImage("manufacturers", ManufacturerId, ManufacturerImagePath);
        }
        
        public void AddManufacturerImage(long ManufacturerId, byte[] ManufacturerImage)
        {
            this.AddImage("manufacturers", ManufacturerId, ManufacturerImage);
        }

        public void UpdateManufacturerImage(long ManufacturerId, string ManufacturerImagePath)
        {
            this.UpdateImage("manufacturers", ManufacturerId, null, ManufacturerImagePath);
        }

        public void UpdateManufacturerImage(long ManufacturerId, byte[] ManufacturerImage)
        {
            this.UpdateImage("manufacturers", ManufacturerId, null, ManufacturerImage);
        }

        public void DeleteManufacturerImage(long ManufacturerId)
        {
            this.DeleteImage("manufacturers", ManufacturerId, null);
        }

        public byte[] GetManufacturerImage(long ManufacturerId, long ImageId)
        {
            RestRequest request = this.RequestForGet("images/manufacturers/" + ManufacturerId, ImageId, "");
            return this.ExecuteForImage(request);
        }

        #endregion Manufacturer images

        #region Product images

        public List<Entities.image> GetAllProductImages()
        {
            return this.GetAllImages("products");
        }

        public List<Entities.imagetype> GetAllProductImageTypes()
        {
            return this.GetAllImageTypes("products");
        }

        public List<Entities.FilterEntities.declination> GetProductImages(long ProductId)
        {
            return this.GetImagesByInstance("products", ProductId);
        }

        public long AddProductImage(long ProductId, string ProductImagePath)
        {
            long r = 0;
            List<Entities.FilterEntities.declination> dif, pre, post;
            try
            {
                pre = this.GetProductImages(ProductId);
            } catch(Exception e)
            {
                // No images...
                pre = new List<Entities.FilterEntities.declination>();
            }

            this.AddImage("products", ProductId, ProductImagePath);

            try
            {
                post = this.GetProductImages(ProductId);
            }
            catch (Exception e)
            {
                // No images...This should not happen. Throw exception from here for better debug.
                throw e;
            }

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
                pre = this.GetProductImages(ProductId);
            }
            catch (Exception e)
            {
                // No images...
                pre = new List<Entities.FilterEntities.declination>();
            }

            this.AddImage("products", ProductId, ProductImage);

            try
            {
                post = this.GetProductImages(ProductId);
            }
            catch (Exception e)
            {
                // No images...This should not happen. Throw exception from here for better debug.
                throw e;
            }

            dif = post.Except(pre, new Helpers.CompareDeclination()).ToList();
            if (dif.Count > 0) r = dif[0].id;
            return r;
        }

        public void UpdateProductImage(long ProductId, long ImageId, string ProductImagePath)
        {
            this.UpdateImage("products", ProductId, ImageId, ProductImagePath);
        }

        public void UpdateProductImage(long ProductId, long ImageId, byte[] ProductImage)
        {
            this.UpdateImage("products", ProductId, ImageId, ProductImage);
        }

        public void DeleteProductImage(long ProductId,long ImageId)
        {
            this.DeleteImage("products", ProductId, ImageId);
        }

        public byte[] GetProductImage(long ProductId, long ImageId)
        {
            RestRequest request = this.RequestForGet("images/products/" + ProductId, ImageId, "");
            return this.ExecuteForImage(request);
        }

        #endregion Product images

        #region Category images

        public List<Entities.image> GetAllCategoryImages()
        {
            return this.GetAllImages("categories");
        }

        public List<Entities.imagetype> GetAllCategoryImageTypes()
        {
            return this.GetAllImageTypes("categories");
        }

        public void AddCategoryImage(long? CategoryId, string CategoryImagePath)
        {
            this.AddImage("categories", CategoryId, CategoryImagePath);
        }
        
        public void AddCategoryImage(long? CategoryId, byte[] CategoryImage)
        {
            this.AddImage("categories", CategoryId, CategoryImage);
        }

        public void UpdateCategoryImage(long CategoryId, string CategoryImagePath)
        {
            this.UpdateImage("categories", CategoryId, null, CategoryImagePath);
        }

        public void UpdateCategoryImage(long CategoryId, byte[] CategoryImage)
        {
            this.UpdateImage("categories", CategoryId, null, CategoryImage);
        }

        public void DeleteCategoryImage(long CategoryID)
        {
            this.DeleteImage("categories", CategoryID, null);
        }

        public byte[] GetCategoryImage(long CategoryId, long ImageId)
        {
            RestRequest request = this.RequestForGet("images/categories/" + CategoryId, ImageId, "");
            return this.ExecuteForImage(request);
        }

        public byte[] GetCategoryImage(long CategoryId, string TypeName)
        {
            RestRequest request = this.RequestForGetType("images/categories/" + CategoryId, TypeName, "");
            return this.ExecuteForImage(request);
        }

        #endregion Category images

    }
}

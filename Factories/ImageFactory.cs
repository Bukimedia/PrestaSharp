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
            this.DeleteImage(Resource, ResourceId, ImageId);
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

        protected Task<List<Entities.image>> GetAllImagesTask(string Resource)
        {
            RestRequest request = this.RequestForFilter("images/" + Resource, "full", null, null, null, "images");
            return this.ExecuteTask<List<Entities.image>>(request);
        }

        protected Task<List<Entities.imagetype>> GetAllImageTypesTask(string Resource)
        {
            RestRequest request = this.RequestForFilter("images/" + Resource, "full", null, null, null, "image_types");
            return this.ExecuteTask<List<Entities.imagetype>>(request);
        }

        protected async Task<List<Entities.FilterEntities.declination>> GetImagesByInstanceTask(string Resource, long Id)
        {
            RestRequest request = this.RequestForFilter("images/" + Resource + "/" + Id, "full", null, null, null, "image");
            var Declinations = await ExecuteTask<List<Entities.FilterEntities.declination>>(request);
            return Declinations.Distinct().ToList();
        }

        protected Task<Entities.image> AddImageTask(string Resource, long? Id, string ImagePath)
        {
            RestRequest request = this.RequestForAddImage(Resource, Id, ImagePath);
            return this.ExecuteTask<Entities.image>(request);
        }

        protected Task<Entities.image> AddImageTask(string Resource, long? Id, byte[] Image, string imageFileName = null)
        {
            RestRequest request = this.RequestForAddImage(Resource, Id, Image, imageFileName);
            return this.ExecuteTask<Entities.image>(request);
        }

        protected async Task<Entities.image> UpdateImageTask(string Resource, long? ResourceId, long? ImageId, string ImagePath)
        {
            await DeleteImageTask(Resource, ResourceId, ImageId);
            return await AddImageTask(Resource, ResourceId, ImagePath);
        }

        protected async Task<Entities.image> UpdateImageTask(string Resource, long? ResourceId, long? ImageId, byte[] Image, string imageFileName = null)
        {
            await DeleteImageTask(Resource, ResourceId, ImageId);
            return await AddImageTask(Resource, ResourceId, Image, imageFileName);
        }

        protected Task DeleteImageTask(string Resource, long? ResourceId, long? ImageId)
        {
            RestRequest request = this.RequestForDeleteImage(Resource, ResourceId, ImageId);
            return ExecuteTask<Entities.image>(request);
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

        public Task<List<Entities.image>> GetAllManufacturerImagesTask()
        {
            return GetAllImagesTask("manufacturers");
        }
        public Task<List<Entities.imagetype>> GetAllManufacturerImageTypesTask()
        {
            return GetAllImageTypesTask("manufacturers");
        }

        public Task AddManufacturerImageTask(long ManufacturerId, string ManufacturerImagePath)
        {
            return AddImageTask("manufacturers", ManufacturerId, ManufacturerImagePath);
        }

        public Task AddManufacturerImageTask(long ManufacturerId, byte[] ManufacturerImage)
        {
            return AddImageTask("manufacturers", ManufacturerId, ManufacturerImage);
        }

        public Task UpdateManufacturerImageTask(long ManufacturerId, string ManufacturerImagePath)
        {
            return UpdateImageTask("manufacturers", ManufacturerId, null, ManufacturerImagePath);
        }

        public Task UpdateManufacturerImageTask(long ManufacturerId, byte[] ManufacturerImage)
        {
            return UpdateImageTask("manufacturers", ManufacturerId, null, ManufacturerImage);
        }

        public Task DeleteManufacturerImageTask(long ManufacturerId)
        {
            return DeleteImageTask("manufacturers", ManufacturerId, null);
        }

        public Task<byte[]> GetManufacturerImageTask(long ManufacturerId, long ImageId)
        {
            RestRequest request = this.RequestForGet("images/manufacturers/" + ManufacturerId, ImageId, "");
            return ExecuteForImageTask(request);
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
            }
            catch (Exception e)
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

        public void DeleteProductImage(long ProductId, long ImageId)
        {
            this.DeleteImage("products", ProductId, ImageId);
        }

        public byte[] GetProductImage(long ProductId, long ImageId)
        {
            RestRequest request = this.RequestForGet("images/products/" + ProductId, ImageId, "");
            return this.ExecuteForImage(request);
        }

        public Task<List<Entities.image>> GetAllProductImagesTask()
        {
            return this.GetAllImagesTask("products");
        }

        public Task<List<Entities.imagetype>> GetAllProductImageTypesTask()
        {
            return this.GetAllImageTypesTask("products");
        }

        public Task<List<Entities.FilterEntities.declination>> GetProductImagesTask(long ProductId)
        {
            return this.GetImagesByInstanceTask("products", ProductId);
        }

        public async Task<long> AddProductImageTask(long ProductId, string ProductImagePath)
        {
            return (await this.AddImageTask("products", ProductId, ProductImagePath)).id;
        }

        public async Task<long> AddProductImageTask(long ProductId, byte[] ProductImage, string imageFileName = null)
        {
            return (await this.AddImageTask("products", ProductId, ProductImage, imageFileName)).id;
        }

        public Task UpdateProductImageTask(long ProductId, long ImageId, string ProductImagePath)
        {
            return UpdateImageTask("products", ProductId, ImageId, ProductImagePath);
        }

        public Task UpdateProductImageTask(long ProductId, long ImageId, byte[] ProductImage)
        {
            return UpdateImageTask("products", ProductId, ImageId, ProductImage);
        }

        public Task DeleteProductImageTask(long ProductId, long ImageId)
        {
            return DeleteImageTask("products", ProductId, ImageId);
        }

        public Task<byte[]> GetProductImageTask(long ProductId, long ImageId)
        {
            RestRequest request = this.RequestForGet("images/products/" + ProductId, ImageId, "");
            return this.ExecuteForImageTask(request);
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

        public Task<List<Entities.image>> GetAllCategoryImagesTask()
        {
            return GetAllImagesTask("categories");
        }

        public Task<List<Entities.imagetype>> GetAllCategoryImageTypesTask()
        {
            return GetAllImageTypesTask("categories");
        }

        public Task AddCategoryImageTask(long? CategoryId, string CategoryImagePath)
        {
            return AddImageTask("categories", CategoryId, CategoryImagePath);
        }

        public Task AddCategoryImageTask(long? CategoryId, byte[] CategoryImage)
        {
            return AddImageTask("categories", CategoryId, CategoryImage);
        }

        public Task UpdateCategoryImageTask(long CategoryId, string CategoryImagePath)
        {
            return UpdateImageTask("categories", CategoryId, null, CategoryImagePath);
        }

        public Task UpdateCategoryImageTask(long CategoryId, byte[] CategoryImage)
        {
            return UpdateImageTask("categories", CategoryId, null, CategoryImage);
        }

        public Task DeleteCategoryImageTask(long CategoryID)
        {
            return DeleteImageTask("categories", CategoryID, null);
        }

        public Task<byte[]> GetCategoryImageTask(long CategoryId, long ImageId)
        {
            RestRequest request = this.RequestForGet("images/categories/" + CategoryId, ImageId, "");
            return ExecuteForImageTask(request);
        }

        public Task<byte[]> GetCategoryImageTask(long CategoryId, string TypeName)
        {
            RestRequest request = this.RequestForGetType("images/categories/" + CategoryId, TypeName, "");
            return ExecuteForImageTask(request);
        }

        #endregion Category images

    }
}

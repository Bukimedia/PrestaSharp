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

        protected Task<List<Entities.image>> GetAllImagesAsync(string Resource)
        {
            RestRequest request = this.RequestForFilter("images/" + Resource, "full", null, null, null, "images");
            return this.ExecuteAsync<List<Entities.image>>(request);
        }

        protected Task<List<Entities.imagetype>> GetAllImageTypesAsync(string Resource)
        {
            RestRequest request = this.RequestForFilter("images/" + Resource, "full", null, null, null, "image_types");
            return this.ExecuteAsync<List<Entities.imagetype>>(request);
        }

        protected async Task<List<Entities.FilterEntities.declination>> GetImagesByInstanceAsync(string Resource, long Id)
        {
            RestRequest request = this.RequestForFilter("images/" + Resource + "/" + Id, "full", null, null, null, "image");
            var Declinations = await ExecuteAsync<List<Entities.FilterEntities.declination>>(request);
            return Declinations.Distinct().ToList();
        }

        protected Task<Entities.image> AddImageAsync(string Resource, long? Id, string ImagePath)
        {
            RestRequest request = this.RequestForAddImage(Resource, Id, ImagePath);
            return this.ExecuteAsync<Entities.image>(request);
        }

        protected Task<Entities.image> AddImageAsync(string Resource, long? Id, byte[] Image, string imageFileName = null)
        {
            RestRequest request = this.RequestForAddImage(Resource, Id, Image, imageFileName);
            return this.ExecuteAsync<Entities.image>(request);
        }

        protected async Task<Entities.image> UpdateImageAsync(string Resource, long? ResourceId, long? ImageId, string ImagePath)
        {
            await DeleteImageAsync(Resource, ResourceId, ImageId);
            return await AddImageAsync(Resource, ResourceId, ImagePath);
        }

        protected async Task<Entities.image> UpdateImageAsync(string Resource, long? ResourceId, long? ImageId, byte[] Image, string imageFileName = null)
        {
            await DeleteImageAsync(Resource, ResourceId, ImageId);
            return await AddImageAsync(Resource, ResourceId, Image, imageFileName);
        }

        protected Task DeleteImageAsync(string Resource, long? ResourceId, long? ImageId)
        {
            RestRequest request = this.RequestForDeleteImage(Resource, ResourceId, ImageId);
            return ExecuteAsync<Entities.image>(request);
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

        public Task<List<Entities.image>> GetAllManufacturerImagesAsync()
        {
            return GetAllImagesAsync("manufacturers");
        }
        public Task<List<Entities.imagetype>> GetAllManufacturerImageTypesAsync()
        {
            return GetAllImageTypesAsync("manufacturers");
        }

        public Task AddManufacturerImageAsync(long ManufacturerId, string ManufacturerImagePath)
        {
            return AddImageAsync("manufacturers", ManufacturerId, ManufacturerImagePath);
        }

        public Task AddManufacturerImageAsync(long ManufacturerId, byte[] ManufacturerImage)
        {
            return AddImageAsync("manufacturers", ManufacturerId, ManufacturerImage);
        }

        public Task UpdateManufacturerImageAsync(long ManufacturerId, string ManufacturerImagePath)
        {
            return UpdateImageAsync("manufacturers", ManufacturerId, null, ManufacturerImagePath);
        }

        public Task UpdateManufacturerImageAsync(long ManufacturerId, byte[] ManufacturerImage)
        {
            return UpdateImageAsync("manufacturers", ManufacturerId, null, ManufacturerImage);
        }

        public Task DeleteManufacturerImageAsync(long ManufacturerId)
        {
            return DeleteImageAsync("manufacturers", ManufacturerId, null);
        }

        public Task<byte[]> GetManufacturerImageAsync(long ManufacturerId, long ImageId)
        {
            RestRequest request = this.RequestForGet("images/manufacturers/" + ManufacturerId, ImageId, "");
            return ExecuteForImageAsync(request);
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

        public Task<List<Entities.image>> GetAllProductImagesAsync()
        {
            return this.GetAllImagesAsync("products");
        }

        public Task<List<Entities.imagetype>> GetAllProductImageTypesAsync()
        {
            return this.GetAllImageTypesAsync("products");
        }

        public Task<List<Entities.FilterEntities.declination>> GetProductImagesAsync(long ProductId)
        {
            return this.GetImagesByInstanceAsync("products", ProductId);
        }

        public async Task<long> AddProductImageAsync(long ProductId, string ProductImagePath)
        {
            return (await this.AddImageAsync("products", ProductId, ProductImagePath)).id;
        }

        public async Task<long> AddProductImageAsync(long ProductId, byte[] ProductImage, string imageFileName = null)
        {
            return (await this.AddImageAsync("products", ProductId, ProductImage, imageFileName)).id;
        }

        public Task UpdateProductImageAsync(long ProductId, long ImageId, string ProductImagePath)
        {
            return UpdateImageAsync("products", ProductId, ImageId, ProductImagePath);
        }

        public Task UpdateProductImageAsync(long ProductId, long ImageId, byte[] ProductImage)
        {
            return UpdateImageAsync("products", ProductId, ImageId, ProductImage);
        }

        public Task DeleteProductImageAsync(long ProductId, long ImageId)
        {
            return DeleteImageAsync("products", ProductId, ImageId);
        }

        public Task<byte[]> GetProductImageAsync(long ProductId, long ImageId)
        {
            RestRequest request = this.RequestForGet("images/products/" + ProductId, ImageId, "");
            return this.ExecuteForImageAsync(request);
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

        public Task<List<Entities.image>> GetAllCategoryImagesAsync()
        {
            return GetAllImagesAsync("categories");
        }

        public Task<List<Entities.imagetype>> GetAllCategoryImageTypesAsync()
        {
            return GetAllImageTypesAsync("categories");
        }

        public Task AddCategoryImageAsync(long? CategoryId, string CategoryImagePath)
        {
            return AddImageAsync("categories", CategoryId, CategoryImagePath);
        }

        public Task AddCategoryImageAsync(long? CategoryId, byte[] CategoryImage)
        {
            return AddImageAsync("categories", CategoryId, CategoryImage);
        }

        public Task UpdateCategoryImageAsync(long CategoryId, string CategoryImagePath)
        {
            return UpdateImageAsync("categories", CategoryId, null, CategoryImagePath);
        }

        public Task UpdateCategoryImageAsync(long CategoryId, byte[] CategoryImage)
        {
            return UpdateImageAsync("categories", CategoryId, null, CategoryImage);
        }

        public Task DeleteCategoryImageAsync(long CategoryID)
        {
            return DeleteImageAsync("categories", CategoryID, null);
        }

        public Task<byte[]> GetCategoryImageAsync(long CategoryId, long ImageId)
        {
            RestRequest request = this.RequestForGet("images/categories/" + CategoryId, ImageId, "");
            return ExecuteForImageAsync(request);
        }

        public Task<byte[]> GetCategoryImageAsync(long CategoryId, string TypeName)
        {
            RestRequest request = this.RequestForGetType("images/categories/" + CategoryId, TypeName, "");
            return ExecuteForImageAsync(request);
        }

        #endregion Category images

    }
}

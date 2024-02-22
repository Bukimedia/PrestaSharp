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

        protected bool CheckImage(string Resource, long? ResourceId, long? ImageId)
        {
            RestRequest request = RequestForHeadImage(Resource, ResourceId, ImageId);
            return ExecuteHead(request);
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

        protected Task<bool> CheckImageAsync(string Resource, long? ResourceId, long? ImageId)
        {
            RestRequest request = RequestForHeadImage(Resource, ResourceId, ImageId);
            return ExecuteHeadAsync(request);
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

        /// <summary>
        /// Checks if manufacturer have image and return true or false
        /// </summary>
        /// <param name="ManufacturerId"></param>
        /// <returns></returns>
        public bool CheckIfExistsManufacturerImage(long ManufacturerId)
        {
            return CheckImage("manufacturers", ManufacturerId, null);
        }

        public byte[] GetManufacturerImage(long ManufacturerId, long ImageId)
        {
            RestRequest request = RequestForGet("images/manufacturers/" + ManufacturerId, ImageId, "");
            return ExecuteForImage(request);
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

        /// <summary>
        /// Checks if manufacturer have image and return true or false
        /// </summary>
        /// <param name="ManufacturerId"></param>
        /// <returns></returns>
        public async Task<bool> CheckIfExistsManufacturerImageAsync(long ManufacturerId)
        {
            return await CheckImageAsync("manufacturers", ManufacturerId, null);
        }

        public Task<byte[]> GetManufacturerImageAsync(long ManufacturerId, long ImageId)
        {
            RestRequest request = this.RequestForGet("images/manufacturers/" + ManufacturerId, ImageId, "");
            return ExecuteForImageAsync(request);
        }

        #endregion Manufacturer images

        #region Supplier images

        public List<Entities.image> GetAllSupplierImages()
        {
            return GetAllImages("suppliers");
        }

        public List<Entities.imagetype> GetAllSupplierImageTypes()
        {
            return GetAllImageTypes("suppliers");
        }

        public void AddSupplierImage(long SupplierId, string SupplierImagePath)
        {
            AddImage("suppliers", SupplierId, SupplierImagePath);
        }

        public void AddSupplierImage(long SupplierId, byte[] SupplierImage)
        {
            AddImage("suppliers", SupplierId, SupplierImage);
        }

        public void UpdateSupplierImage(long SupplierId, string SupplierImagePath)
        {
            UpdateImage("suppliers", SupplierId, null, SupplierImagePath);
        }

        public void UpdateSupplierImage(long SupplierId, byte[] SupplierImage)
        {
            UpdateImage("suppliers", SupplierId, null, SupplierImage);
        }

        public void DeleteSupplierImage(long SupplierId)
        {
            DeleteImage("suppliers", SupplierId, null);
        }

        /// <summary>
        /// Checks if supplier have image and return true or false
        /// </summary>
        /// <param name="SupplierId"></param>
        /// <returns></returns>
        public bool CheckIfExistsSupplierImage(long SupplierId)
        {
            return CheckImage("suppliers", SupplierId, null);
        }

        public byte[] GetSupplierImage(long SupplierId, long ImageId)
        {
            RestRequest request = RequestForGet("images/suppliers/" + SupplierId, ImageId, "");
            return ExecuteForImage(request);
        }

        public Task<List<Entities.image>> GetAllSupplierImagesAsync()
        {
            return GetAllImagesAsync("suppliers");
        }
        public Task<List<Entities.imagetype>> GetAllSupplierImageTypesAsync()
        {
            return GetAllImageTypesAsync("suppliers");
        }

        public Task AddSupplierImageAsync(long SupplierId, string SupplierImagePath)
        {
            return AddImageAsync("suppliers", SupplierId, SupplierImagePath);
        }

        public Task AddSupplierImageAsync(long SupplierId, byte[] SupplierImage)
        {
            return AddImageAsync("suppliers", SupplierId, SupplierImage);
        }

        public Task UpdateSupplierImageAsync(long SupplierId, string SupplierImagePath)
        {
            return UpdateImageAsync("suppliers", SupplierId, null, SupplierImagePath);
        }

        public Task UpdateSupplierImageAsync(long SupplierId, byte[] SupplierImage)
        {
            return UpdateImageAsync("suppliers", SupplierId, null, SupplierImage);
        }

        public Task DeleteSupplierImageAsync(long SupplierId)
        {
            return DeleteImageAsync("suppliers", SupplierId, null);
        }

        /// <summary>
        /// Checks if supplier have image and return true or false
        /// </summary>
        /// <param name="SupplierId"></param>
        /// <returns></returns>
        public async Task<bool> CheckIfExistsSupplierImageAsync(long SupplierId)
        {
            return await CheckImageAsync("suppliers", SupplierId, null);
        }

        public Task<byte[]> GetSupplierImageAsync(long SupplierId, long ImageId)
        {
            RestRequest request = this.RequestForGet("images/suppliers/" + SupplierId, ImageId, "");
            return ExecuteForImageAsync(request);
        }

        #endregion Supplier images

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

        /// <summary>
        /// If Image ID is null checks if product have any images
        /// else checks if the specific product image exists
        /// and return true or false
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="ImageId"></param>
        /// <returns></returns>
        public bool CheckIfExistsProductImage(long ProductId, long? ImageId)
        {
            return CheckImage("products", ProductId, ImageId);
        }

        public byte[] GetProductImage(long ProductId, long ImageId)
        {
            RestRequest request = RequestForGet("images/products/" + ProductId, ImageId, "");
            return ExecuteForImage(request);
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

        /// <summary>
        /// If Image ID is null checks if product have any images
        /// else checks if the specific product image exists
        /// and return true or false
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="ImageId"></param>
        /// <returns></returns>
        public async Task<bool> CheckIfExistsProductImageAsync(long ProductId, long ImageId)
        {
            return await CheckImageAsync("products", ProductId, ImageId);
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

        /// <summary>
        /// Checks if the category have image and return true or false
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public bool CheckIfExistsCategoryImage(long CategoryID)
        {
            return CheckImage("categories", CategoryID, null);
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

        /// <summary>
        ///  Checks if the category have image and return true or false
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public async Task<bool> CheckIfExistsCategoryImageAsync(long CategoryID)
        {
            return await CheckImageAsync("categories", CategoryID, null);
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Business.Abstract;
using ZeusERP.Business.Constants;
using ZeusERP.Core.Utilities.Results;
using ZeusERP.DataAccess.Abstract;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDao _productDao;
        private ICategoryDao _categoryDao;
        public ProductManager(IProductDao productDao, ICategoryDao categoryDao)
        {
            _productDao = productDao;
            _categoryDao = categoryDao;
        }
        /// <summary>
        /// /Returns the entire product list.
        /// </summary>
        /// <returns></returns>
        public IDataResult<IList<Product>> GetList()
        {
            return new SuccessDataResult<IList<Product>>(_productDao.GetList());
        }
        /// <summary>
        /// Returns the entire product list asynchronously.
        /// </summary>
        /// <returns>List<Product></returns>
        public async Task<IDataResult<IList<Product>>> GetListAsync()
        {
            var products = await _productDao.GetListAsync();
            return new SuccessDataResult<IList<Product>>(products);
        }
        /// <summary>
        /// Returns a product with the given id.
        /// </summary>
        /// <param name="productId">Product's ID.</param>
        /// <returns>A product</returns>
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDao.Get(p => p.Id == productId));
        }
        /// <summary>
        /// Returns a product with the given id asynchronously.
        /// </summary>
        /// <param name="productId">Product's ID.</param>
        /// <returns>A product</returns>
        public async Task<IDataResult<Product>> GetByIdAsync(int productId)
        {
            var product = await _productDao.GetAsync(p => p.Id == productId);
            return new SuccessDataResult<Product>(product);
        }
        /// <summary>
        /// Returns a product that belongs to a category with given id.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public IDataResult<ProductWithCategory> GetProductWithCategory(int productId)
        {
            var product = _productDao.Get(p => p.Id == productId) as Product;
            var category = _categoryDao.Get(c => c.Id == product.CategoryId) as Category;

            var productWithCategory = new ProductWithCategory(product, category);

            return new SuccessDataResult<ProductWithCategory>(productWithCategory);
        }
        /// <summary>
        /// Returns a product that belongs to a category with given id asynchronously.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>A product.</returns>
        public async Task<IDataResult<ProductWithCategory>> GetProductWithCategoryAsync(int productId)
        {
            var product = await _productDao.GetAsync(p => p.CategoryId == productId) as Product;
            var category = _categoryDao.Get(c => c.Id == product.CategoryId) as Category;

            var productWithCategory = new ProductWithCategory(product, category);

            return new SuccessDataResult<ProductWithCategory>(productWithCategory);
        }
        /// <summary>
        /// Returns all product that belong to the given category id.
        /// </summary>
        /// <param name="categoryId">Category Id.</param>
        /// <returns></returns>
        public IDataResult<IList<ProductWithCategory>> GetProductListByCategory(int categoryId)
        {
            var category = _categoryDao.Get(c => c.Id == categoryId) as Category;
            var products = _productDao.GetList(p => p.CategoryId == categoryId) as List<Product>;

            var productsWithCategory = new List<ProductWithCategory>();
            products.ForEach(p =>
            {
                productsWithCategory.Add(new ProductWithCategory(p, category));
            });

            return new SuccessDataResult<IList<ProductWithCategory>>(productsWithCategory);
        }
        /// <summary>
        /// Returns all products that belong to the given category id asynchronously.
        /// </summary>
        /// <param name="categoryId">Category Id.</param>
        /// <returns></returns>
        public async Task<IDataResult<IList<ProductWithCategory>>> GetProductListByCategoryAsync(int categoryId)
        {
            var category = await _categoryDao.GetAsync(c => c.Id == categoryId) as Category;
            var products = await _productDao.GetListAsync(p => p.CategoryId == categoryId) as List<Product>;

            var productsWithCategory = new List<ProductWithCategory>();
            products.ForEach(p =>
            {
                productsWithCategory.Add(new ProductWithCategory(p, category));
            });
            return new SuccessDataResult<IList<ProductWithCategory>>(productsWithCategory);
        }
        /// <summary>
        /// Returns all product that belong to the given category id as a complex type.
        /// </summary>
        /// <returns></returns>
        public IDataResult<IList<ProductWithCategory>> GetProductListWithCategory()
        {
            var products = _productDao.GetList() as List<Product>;
            var productsWithCategories = new List<ProductWithCategory>();
            products.ForEach(p =>
            {
                var category = _categoryDao.Get(c => c.Id == p.CategoryId);
                productsWithCategories.Add(new ProductWithCategory(p, category));
            });
            return new SuccessDataResult<IList<ProductWithCategory>>(productsWithCategories);
        }
        /// <summary>
        /// Returns all product that belong to the given category id as a complex type asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task<IDataResult<IList<ProductWithCategory>>> GetProductListWithCategoryAsync()
        {
            var products = await _productDao.GetListAsync() as List<Product>;
            var productsWithCategories = new List<ProductWithCategory>();

            products.ForEach(async p =>
            {
                var category = await _categoryDao.GetAsync(c => c.Id == p.CategoryId);
                productsWithCategories.Add(new ProductWithCategory(p, category));
            });

            return new SuccessDataResult<IList<ProductWithCategory>>(productsWithCategories);
        }

        public IResult Add(Product product)
        {
            _productDao.Add(product);
            return new SuccessResult(true, ResultMessages.ProductAdded);
        }
        public async Task<IResult> AddAsync(Product product)
        {
            await _productDao.AddAsync(product);
            return new SuccessResult(true, ResultMessages.ProductAdded);
        }

        public IResult Update(Product product)
        {
            _productDao.Update(product);
            return new SuccessResult(true, ResultMessages.ProductUpdated);
        }
        public async Task<IResult> UpdateAsync(Product product)
        {
            await _productDao.UpdateAsync(product);
            return new SuccessResult(true, ResultMessages.ProductUpdated);
        }

        public IResult Delete(Product product)
        {
            _productDao.Delete(product);
            return new SuccessResult(true, ResultMessages.ProductDeleted);
        }
        public async Task<IResult> DeleteAsync(Product product)
        {
            await _productDao.DeleteAsync(product);
            return new SuccessResult(true, ResultMessages.ProductDeleted);
        }
    }
}
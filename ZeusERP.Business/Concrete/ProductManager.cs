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

        public IDataResult<IList<Product>> GetList()
        {
            return new SuccessDataResult<IList<Product>>(_productDao.GetList());
        }
        public async Task<IDataResult<IList<Product>>> GetListAsync()
        {
            var products = await _productDao.GetListAsync();
            return new SuccessDataResult<IList<Product>>(products);
        }
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDao.Get(p => p.Id == productId));
        }

        public async Task<IDataResult<Product>> GetByIdAsync(int productId)
        {
            var product = await _productDao.GetAsync(p => p.Id == productId);
            return new SuccessDataResult<Product>(product);
        }
        public IDataResult<ProductWithCategory> GetProductWithCategory(int productId, int categoryId)
        {
            var category = _categoryDao.Get(c => c.Id == categoryId) as Category;
            var product = _productDao.Get(p => p.CategoryId == categoryId) as Product;

            var productWithCategory = new ProductWithCategory(product, category);

            return new SuccessDataResult<ProductWithCategory>(productWithCategory);
        }
        public async Task<IDataResult<ProductWithCategory>> GetProductWithCategoryAsync(int productId, int categoryId)
        {
            var category = await _categoryDao.GetAsync(c => c.Id == categoryId) as Category;
            var product = await _productDao.GetAsync(p => p.CategoryId == categoryId) as Product;

            var productWithCategory = new ProductWithCategory(product, category);

            return new SuccessDataResult<ProductWithCategory>(productWithCategory);
        }

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
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Business.Abstract;
using ZeusERP.Business.Constants;
using ZeusERP.Core.Utilities.Results;
using ZeusERP.DataAccess.Abstract;
using ZeusERP.Entities.Concrete;

namespace ZeusERP.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDao _categoryDao;
        public CategoryManager(ICategoryDao categoryDao)
        {
            _categoryDao = categoryDao;
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDao.Get(c => c.Id == categoryId));
        }

        public async Task<IDataResult<Category>> GetByIdAsync(int categoryId)
        {
            var category = await _categoryDao.GetAsync(c => c.Id == categoryId);
            return new SuccessDataResult<Category>(category);
        }

        public IDataResult<Category> GetByName(string categoryName)
        {
            return new SuccessDataResult<Category>(_categoryDao.Get(c => c.Name == categoryName));
        }

        public async Task<IDataResult<Category>> GetByNameAsync(string categoryName)
        {
            var category = await _categoryDao.GetAsync(c => c.Name == categoryName);
            return new SuccessDataResult<Category>(category);
        }

        public IDataResult<IList<Category>> GetList()
        {
            return new SuccessDataResult<IList<Category>>(_categoryDao.GetList());
        }
        public async Task<IDataResult<IList<Category>>> GetListAsync()
        {
            var categories = await _categoryDao.GetListAsync();
            return new SuccessDataResult<IList<Category>>(categories);
        }

        public IResult Add(Category category)
        {
            _categoryDao.Add(category);
            return new SuccessResult(true, ResultMessages.CategoryAdded);
        }

        public async Task<IResult> AddAsync(Category category)
        {
            await _categoryDao.AddAsync(category);
            return new SuccessResult(true, ResultMessages.CategoryAdded);
        }

        public IResult Update(Category category)
        {
            _categoryDao.Update(category);
            return new SuccessResult(true, ResultMessages.CategoryUpdated);
        }

        public async Task<IResult> UpdateAsync(Category category)
        {
            await _categoryDao.UpdateAsync(category);
            return new SuccessResult(true, ResultMessages.CategoryUpdated);
        }

        public IResult Delete(Category category)
        {
            _categoryDao.Delete(category);
            return new SuccessResult(true, ResultMessages.CategoryDeleted);
        }

        public async Task<IResult> DeleteAsync(Category category)
        {
            await _categoryDao.DeleteAsync(category);
            return new SuccessResult(true, ResultMessages.CategoryDeleted);
        }
    }
}

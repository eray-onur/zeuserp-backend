using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> GetById(int categoryId);
        Task<IDataResult<Category>> GetByIdAsync(int categoryId);
        IDataResult<Category> GetByName(string categoryName);
        Task<IDataResult<Category>> GetByNameAsync(string categoryName);
        IDataResult<CategoryDetailsDto> GetCategoryDetailsById(int categoryId);
        Task<IDataResult<CategoryDetailsDto>> GetCategoryDetailsByIdAsync(int categoryId);
        IDataResult<CategoryListDto> GetCategoryList();
        Task<IDataResult<CategoryListDto>> GetCategoryListAsync();
        IDataResult<IList<Category>> GetList();
        Task<IDataResult<IList<Category>>> GetListAsync();
        IResult Add(Category category);
        Task<IResult> AddAsync(Category category);
        IResult Update(Category category);
        Task<IResult> UpdateAsync(Category category);
        IResult Delete(Category category);
        Task<IResult> DeleteAsync(Category category);
    }
}

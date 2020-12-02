using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<IList<Product>> GetList();
        Task<IDataResult<IList<Product>>> GetListAsync();
        IDataResult<Product> GetById(int productId);
        Task<IDataResult<Product>> GetByIdAsync(int productId);
        IDataResult<ProductDetailsDto> GetProductDetailsById(int productId);
        Task<IDataResult<ProductDetailsDto>> GetProductDetailsByIdAsync(int productId);
        IDataResult<IList<ProductListDto>> GetProductListItems();
        Task<IDataResult<IList<ProductListDto>>> GetProductListItemsAsync();
        IResult Add(Product product);
        Task<IResult> AddAsync(Product product);

        IResult Update(Product product);
        Task<IResult> UpdateAsync(Product product);

        IResult Delete(Product product);
        Task<IResult> DeleteAsync(Product product);
    }
}

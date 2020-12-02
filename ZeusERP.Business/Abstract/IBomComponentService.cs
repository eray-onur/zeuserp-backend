using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;

namespace ZeusERP.Business.Abstract
{
    public interface IBomComponentService
    {
        IDataResult<BillOfMaterialsComponent> GetById(int bomComponentId);
        Task<IDataResult<BillOfMaterialsComponent>> GetByIdAsync(int bomComponentId);
        IDataResult<IList<BillOfMaterialsComponent>> GetList();
        Task<IDataResult<IList<BillOfMaterialsComponent>>> GetListAsync();
        IResult Add(BillOfMaterialsComponent bomComponent);
        Task<IResult> AddAsync(BillOfMaterialsComponent bomComponent);
        IResult Update(BillOfMaterialsComponent bomComponent);
        Task<IResult> UpdateAsync(BillOfMaterialsComponent bomComponent);
        IResult Delete(BillOfMaterialsComponent bomComponent);
        Task<IResult> DeleteAsync(BillOfMaterialsComponent bomComponent);
    }
}

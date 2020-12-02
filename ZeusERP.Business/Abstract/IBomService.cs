using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Core.Utilities.Results;
using ZeusERP.Entities.Concrete;

namespace ZeusERP.Business.Abstract
{
    public interface IBomService
    {
        IDataResult<BillOfMaterials> GetById(int bomId);
        Task<IDataResult<BillOfMaterials>> GetByIdAsync(int bomId);
        IDataResult<IList<BillOfMaterials>> GetList();
        Task<IDataResult<IList<BillOfMaterials>>> GetListAsync();
        IResult Add(BillOfMaterials bom);
        Task<IResult> AddAsync(BillOfMaterials bom);
        IResult Update(BillOfMaterials bom);
        Task<IResult> UpdateAsync(BillOfMaterials bom);
        IResult Delete(BillOfMaterials bom);
        Task<IResult> DeleteAsync(BillOfMaterials bom);
    }
}

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
    public class BomManager : IBomService
    {
        private IBomDao _bomDao;
        public BomManager(IBomDao bomDao)
        {
            _bomDao = bomDao;
        }
        public IDataResult<BillOfMaterials> GetById(int id)
        {
            return new SuccessDataResult<BillOfMaterials>(_bomDao.Get(c => c.Id == id));
        }

        public async Task<IDataResult<BillOfMaterials>> GetByIdAsync(int id)
        {
            var component = await _bomDao.GetAsync(c => c.Id == id);
            return new SuccessDataResult<BillOfMaterials>(component);
        }

        public IDataResult<IList<BillOfMaterials>> GetList()
        {
            return new SuccessDataResult<IList<BillOfMaterials>>(_bomDao.GetList());
        }

        public async Task<IDataResult<IList<BillOfMaterials>>> GetListAsync()
        {
            var components = await _bomDao.GetListAsync();
            return new SuccessDataResult<IList<BillOfMaterials>>(components);
        }

        public IResult Add(BillOfMaterials bom)
        {
            _bomDao.Add(bom);
            return new SuccessResult(true, ResultMessages.BomComponentAdded);
        }

        public async Task<IResult> AddAsync(BillOfMaterials bom)
        {
            await _bomDao.AddAsync(bom);
            return new SuccessResult(true, ResultMessages.BomComponentAdded);
        }

        public IResult Update(BillOfMaterials bom)
        {
            _bomDao.Update(bom);
            return new SuccessResult(true, ResultMessages.BomComponentUpdated);
        }

        public async Task<IResult> UpdateAsync(BillOfMaterials bom)
        {
            await _bomDao.UpdateAsync(bom);
            return new SuccessResult(true, ResultMessages.BomComponentUpdated);
        }

        public IResult Delete(BillOfMaterials bom)
        {
            _bomDao.Delete(bom);
            return new SuccessResult(true, ResultMessages.BomComponentDeleted);
        }

        public async Task<IResult> DeleteAsync(BillOfMaterials bom)
        {
            await _bomDao.DeleteAsync(bom);
            return new SuccessResult(true, ResultMessages.BomComponentDeleted);
        }

        public IDataResult<BomDetailsDto> GetBomDetailsDtoById(int bomId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<BomDetailsDto>> GetBomDetailsDtoByIdAsync(int bomId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IList<BomListDto>> GetBomListDto()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IList<BomListDto>>> GetBomListDtoAsync()
        {
            throw new NotImplementedException();
        }
    }
}

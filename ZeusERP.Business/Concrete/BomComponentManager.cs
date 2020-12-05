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
    public class BomComponentManager : IBomComponentService
    {
        private  IBomComponentDao _bomComponentDao;
        public BomComponentManager(IBomComponentDao bomComponentDao)
        {
            _bomComponentDao = bomComponentDao;
        }
        public IDataResult<BillOfMaterialsComponent> GetById(int id)
        {
            return new SuccessDataResult<BillOfMaterialsComponent>(_bomComponentDao.Get(c => c.Id == id));
        }

        public async Task<IDataResult<BillOfMaterialsComponent>> GetByIdAsync(int id)
        {
            var component = await _bomComponentDao.GetAsync(c => c.Id == id);
            return new SuccessDataResult<BillOfMaterialsComponent>(component);
        }

        public IDataResult<IList<BillOfMaterialsComponent>> GetList()
        {
            return new SuccessDataResult<IList<BillOfMaterialsComponent>>(_bomComponentDao.GetList());
        }

        public async Task<IDataResult<IList<BillOfMaterialsComponent>>> GetListAsync()
        {
            var components = await _bomComponentDao.GetListAsync();
            return new SuccessDataResult<IList<BillOfMaterialsComponent>>(components);
        }

        public IDataResult<IList<BillOfMaterialsComponent>> GetListByBomId(int bomId)
        {
            var components = _bomComponentDao.GetList(c => c.BoMId == bomId);
            return new SuccessDataResult<IList<BillOfMaterialsComponent>>(components);
        }

        public async Task<IDataResult<IList<BillOfMaterialsComponent>>> GetListByBomIdAsync(int bomId)
        {
            var components = await _bomComponentDao.GetListAsync(c => c.BoMId == bomId);
            return new SuccessDataResult<IList<BillOfMaterialsComponent>>(components);
        }

        public IResult Add(BillOfMaterialsComponent bomComponent)
        {
            _bomComponentDao.Add(bomComponent);
            return new SuccessResult(true, ResultMessages.BomComponentAdded);
        }

        public async Task<IResult> AddAsync(BillOfMaterialsComponent bomComponent)
        {
            await _bomComponentDao.AddAsync(bomComponent);
            return new SuccessResult(true, ResultMessages.BomComponentAdded);
        }

        public IResult Update(BillOfMaterialsComponent bomComponent)
        {
            _bomComponentDao.Update(bomComponent);
            return new SuccessResult(true, ResultMessages.BomComponentUpdated);
        }

        public async Task<IResult> UpdateAsync(BillOfMaterialsComponent bomComponent)
        {
            await _bomComponentDao.UpdateAsync(bomComponent);
            return new SuccessResult(true, ResultMessages.BomComponentUpdated);
        }

        public IResult Delete(BillOfMaterialsComponent bomComponent)
        {
            _bomComponentDao.Delete(bomComponent);
            return new SuccessResult(true, ResultMessages.BomComponentDeleted);
        }

        public async Task<IResult> DeleteAsync(BillOfMaterialsComponent bomComponent)
        {
            await _bomComponentDao.DeleteAsync(bomComponent);
            return new SuccessResult(true, ResultMessages.BomComponentDeleted);
        }

        public IDataResult<BomComponentDetailsDto> GetBomComponentDetailsDtoById(int bomComponentId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<BomComponentDetailsDto>> GetBomComponentDetailsDtoByIdAsync(int bomComponentId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IList<BomComponentListDto>> GetBomComponentListDto()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IList<BomComponentListDto>>> GetBomComponentListDtoAsync()
        {
            throw new NotImplementedException();
        }
    }
}

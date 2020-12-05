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
    public class WarehouseManager : IWarehouseService
    {
        private IWarehouseDao _warehouseDao;
        public WarehouseManager(IWarehouseDao warehouseDao)
        {
            _warehouseDao = warehouseDao;
        }
        public IDataResult<IList<Warehouse>> GetList()
        {
            return new SuccessDataResult<IList<Warehouse>>(_warehouseDao.GetList());
        }

        public async Task<IDataResult<IList<Warehouse>>> GetListAsync()
        {
            var warehouses = await _warehouseDao.GetListAsync();
            return new SuccessDataResult<IList<Warehouse>>(warehouses);
        }

        public IDataResult<Warehouse> GetById(int id)
        {
            return new SuccessDataResult<Warehouse>(_warehouseDao.Get(w => w.Id == id));
        }

        public async Task<IDataResult<Warehouse>> GetByIdAsync(int id)
        {
            var warehouse = await _warehouseDao.GetAsync(w => w.Id == id);
            return new SuccessDataResult<Warehouse>(warehouse);
        }

        public IResult Add(Warehouse warehouse)
        {
            _warehouseDao.Add(warehouse);
            return new SuccessResult(true, ResultMessages.WarehouseAdded);
        }

        public async Task<IResult> AddAsync(Warehouse warehouse)
        {
            await _warehouseDao.AddAsync(warehouse);
            return new SuccessResult(true, ResultMessages.WarehouseAdded);
        }

        public IResult Update(Warehouse warehouse)
        {
            _warehouseDao.Update(warehouse);
            return new SuccessResult(true, ResultMessages.WarehouseUpdated);
        }

        public async Task<IResult> UpdateAsync(Warehouse warehouse)
        {
            await _warehouseDao.UpdateAsync(warehouse);
            return new SuccessResult(true, ResultMessages.WarehouseUpdated);
        }

        public IResult Delete(Warehouse warehouse)
        {
            _warehouseDao.Delete(warehouse);
            return new SuccessResult(true, ResultMessages.WarehouseDeleted);
        }

        public async Task<IResult> DeleteAsync(Warehouse warehouse)
        {
            await _warehouseDao.DeleteAsync(warehouse);
            return new SuccessResult(true, ResultMessages.WarehouseDeleted);
        }

        public IDataResult<WarehouseDetailsDto> GetWarehouseDetailsDtoById(int warehouseId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<WarehouseDetailsDto>> GetWarehouseDetailsDtoByIdAsync(int warehouseId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IList<WarehouseListDto>> GetWarehouseListDto()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IList<WarehouseListDto>>> GetWarehouseListDtoAsync()
        {
            throw new NotImplementedException();
        }
    }
}

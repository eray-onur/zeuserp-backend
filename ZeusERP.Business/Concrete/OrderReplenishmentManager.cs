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
    public class OrderReplenishmentManager : IOrderReplenishmentService
    {
        private IOrderReplenishmentDao _replenishmentDao;

        public OrderReplenishmentManager(IOrderReplenishmentDao replenishmentDao)
        {
            _replenishmentDao = replenishmentDao;
        }

        public IDataResult<IList<Replenishment>> GetList()
        {
            return new SuccessDataResult<IList<Replenishment>>(_replenishmentDao.GetList());
        }

        public async Task<IDataResult<IList<Replenishment>>> GetListAsync()
        {
            var orders = await _replenishmentDao.GetListAsync();
            return new SuccessDataResult<IList<Replenishment>>(orders);
        }

        public IDataResult<Replenishment> GetById(int id)
        {
            return new SuccessDataResult<Replenishment>(_replenishmentDao.Get(r => r.Id == id));
        }

        public async Task<IDataResult<Replenishment>> GetByIdAsync(int id)
        {
            var orders = await _replenishmentDao.GetAsync(r => r.Id == id);
            return new SuccessDataResult<Replenishment>(orders);
        }

        public IResult Add(Replenishment replenishment)
        {
            _replenishmentDao.Add(replenishment);
            return new SuccessResult(true, ResultMessages.ReplenishmentOrderAdded);
        }

        public async Task<IResult> AddAsync(Replenishment replenishment)
        {
            await _replenishmentDao.AddAsync(replenishment);
            return new SuccessResult(true, ResultMessages.ReplenishmentOrderAdded);
        }

        public IResult Update(Replenishment replenishment)
        {
            _replenishmentDao.Update(replenishment);
            return new SuccessResult(true, ResultMessages.ReplenishmentOrderUpdated);
        }

        public async Task<IResult> UpdateAsync(Replenishment replenishment)
        {
           await _replenishmentDao.UpdateAsync(replenishment);
           return new SuccessResult(true, ResultMessages.ReplenishmentOrderUpdated);
        }

        public IResult Delete(Replenishment replenishment)
        {
            _replenishmentDao.Delete(replenishment);
            return new SuccessResult(true, ResultMessages.ReplenishmentOrderDeleted);
        }

        public async Task<IResult> DeleteAsync(Replenishment replenishment)
        {
            await _replenishmentDao.DeleteAsync(replenishment);
            return new SuccessResult(true, ResultMessages.ReplenishmentOrderDeleted);
        }

        public IDataResult<ReplenishmentDetailsDto> GetReplenishmentDetailsDtoById(int replenishmentId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ReplenishmentDetailsDto>> GetReplenishmentDetailsDtoByIdAsync(int replenishmentId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IList<ReplenishmentListDto>> GetReplenishmentListDto()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IList<ReplenishmentListDto>>> GetReplenishmentListDtoAsync()
        {
            throw new NotImplementedException();
        }
    }
}

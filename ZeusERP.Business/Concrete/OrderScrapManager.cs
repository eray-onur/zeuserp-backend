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
    public class OrderScrapManager : IOrderScrapService
    {
        private IOrderScrapDao _scrapDao;
        public OrderScrapManager(IOrderScrapDao scrapDao)
        {
            _scrapDao = scrapDao;
        }
        public IDataResult<IList<Scrap>> GetList()
        {
            return new SuccessDataResult<IList<Scrap>>(_scrapDao.GetList());
        }

        public async Task<IDataResult<IList<Scrap>>> GetListAsync()
        {
            var orders = await _scrapDao.GetListAsync();
            return new SuccessDataResult<IList<Scrap>>(orders);
        }

        public IDataResult<Scrap> GetById(int id)
        {
            return new SuccessDataResult<Scrap>(_scrapDao.Get(s => s.Id == id));
        }

        public async Task<IDataResult<Scrap>> GetByIdAsync(int id)
        {
            var order = await _scrapDao.GetAsync(s => s.Id == id);
            return new SuccessDataResult<Scrap>(order);
        }

        public IResult Add(Scrap scrap)
        {
            _scrapDao.Add(scrap);
            return new SuccessResult(true, ResultMessages.ScrapOrderAdded);
        }

        public async Task<IResult> AddAsync(Scrap scrap)
        {
            await _scrapDao.AddAsync(scrap);
            return new SuccessResult(true, ResultMessages.ScrapOrderAdded);
        }

        public IResult Update(Scrap scrap)
        {
            _scrapDao.Update(scrap);
            return new SuccessResult(true, ResultMessages.ScrapOrderAdded);
        }

        public async Task<IResult> UpdateAsync(Scrap scrap)
        {
            await _scrapDao.UpdateAsync(scrap);
            return new SuccessResult(true, ResultMessages.ScrapOrderUpdated);
        }

        public IResult Delete(Scrap scrap)
        {
            _scrapDao.Delete(scrap);
            return new SuccessResult(true, ResultMessages.ScrapOrderDeleted);
        }

        public async Task<IResult> DeleteAsync(Scrap scrap)
        {
            await _scrapDao.DeleteAsync(scrap);
            return new SuccessResult(true, ResultMessages.ScrapOrderDeleted);
        }

        public IDataResult<ScrapDetailsDto> GetScrapDetailsDtoById(int scrapId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<ScrapDetailsDto>> GetScrapDetailsDtoByIdAsync(int scrapId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IList<ScrapListDto>> GetScrapListDto()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IList<ScrapListDto>>> GetScrapListDtoAsync()
        {
            throw new NotImplementedException();
        }
    }
}

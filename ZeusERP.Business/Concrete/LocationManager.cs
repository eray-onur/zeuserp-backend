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
    public class LocationManager : ILocationService
    {
        private ILocationDao _locationDao;
        public LocationManager(ILocationDao locationDao)
        {
            _locationDao = locationDao;
        }
        public IDataResult<IList<Location>> GetList()
        {
            return new SuccessDataResult<IList<Location>>(_locationDao.GetList());
        }
        public async Task<IDataResult<IList<Location>>> GetListAsync()
        {
            var locations = await _locationDao.GetListAsync();
            return new SuccessDataResult<IList<Location>>(locations);
        }

        public IDataResult<Location> GetById(int id)
        {
            return new SuccessDataResult<Location>(_locationDao.Get(l => l.Id == id));
        }

        public async Task<IDataResult<Location>> GetByIdAsync(int id)
        {
            var location = await _locationDao.GetAsync(l => l.Id == id);
            return new SuccessDataResult<Location>(location);
        }

        public IResult Add(Location location)
        {
            _locationDao.Add(location);
            return new SuccessResult(true, ResultMessages.LocationAdded);
        }

        public async Task<IResult> AddAsync(Location location)
        {
            await _locationDao.AddAsync(location);
            return new SuccessResult(true, ResultMessages.LocationAdded);
        }

        public IResult Update(Location location)
        {
            _locationDao.Update(location);
            return new SuccessResult(true, ResultMessages.LocationUpdated);
        }

        public async Task<IResult> UpdateAsync(Location location)
        {
            await _locationDao.UpdateAsync(location);
            return new SuccessResult(true, ResultMessages.LocationUpdated);
        }

        public IResult Delete(Location location)
        {
            _locationDao.Delete(location);
            return new SuccessResult(true, ResultMessages.LocationDeleted);
        }

        public async Task<IResult> DeleteAsync(Location location)
        {
            await _locationDao.DeleteAsync(location);
            return new SuccessResult(true, ResultMessages.LocationDeleted);
        }

        public IDataResult<LocationDetailsDto> GetLocationDetailsDtoById(int locationId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<LocationDetailsDto>> GetLocationDetailsDtoByIdAsync(int locationId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IList<LocationDetailsDto>> GetLocationListDto()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IList<LocationDetailsDto>>> GetLocationListDtoAsync()
        {
            throw new NotImplementedException();
        }
    }
}

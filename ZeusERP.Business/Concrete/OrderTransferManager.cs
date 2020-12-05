using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using ZeusERP.Business.Abstract;
using ZeusERP.Core.Utilities.Results;
using ZeusERP.DataAccess.Abstract;
using ZeusERP.Entities.Concrete;
using ZeusERP.Entities.Concrete.ComplexTypes;

namespace ZeusERP.Business.Concrete
{
    public class OrderTransferManager : IOrderTransferService
    {
        private IOrderTransferDao _transferDao;
        public OrderTransferManager(IOrderTransferDao transferDao)
        {
            _transferDao = transferDao;
        }
        public IDataResult<IList<Transfer>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IList<Transfer>>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Transfer> GetById(int transferId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Transfer>> GetByIdAsync(int transferId)
        {
            throw new NotImplementedException();
        }

        public IResult Add(Transfer transfer)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> AddAsync(Transfer transfer)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Transfer transfer)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(Transfer transfer)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Transfer transfer)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteAsync(Transfer transfer)
        {
            throw new NotImplementedException();
        }

        public IDataResult<TransferDetailsDto> GetTransferDetailsDtoById(int transferId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<TransferDetailsDto>> GetTransferDetailsDtoByIdAsync(int transferId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IList<TransferListDto>> GetTransferListDto()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<IList<TransferListDto>>> GetTransferListDtoAsync()
        {
            throw new NotImplementedException();
        }
    }
}

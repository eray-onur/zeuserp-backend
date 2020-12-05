using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ZeusERP.Business.Abstract;
using ZeusERP.Entities.Concrete;

namespace ZeusERP.InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferOrdersController : ControllerBase
    {
        private IOrderTransferService _transferService;

        public TransferOrdersController(IOrderTransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpGet("GetAll")]
        public IActionResult Transfers()
        {
            var result = _transferService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> TransfersAsync()
        {
            var result = await _transferService.GetListAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetList")]
        public IActionResult GetTransferListDto()
        {
            var result = _transferService.GetTransferListDto();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetListAsync")]
        public async Task<IActionResult> GetTransferListDtoAsync()
        {
            var result = await _transferService.GetTransferListDtoAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetTransferById(int id)
        {
            var result = _transferService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetAsync/{id}")]
        public async Task<IActionResult> GetTransferByIdAsync(int id)
        {
            var result = await _transferService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetDetails/{id}")]
        public IActionResult GetTransferDetailsDtoById(int id)
        {
            var result = _transferService.GetTransferDetailsDtoById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetDetailsAsync/{id}")]
        public async Task<IActionResult> GetTransferDetailsDtoByIdAsync(int id)
        {
            var result = await _transferService.GetTransferDetailsDtoByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(Transfer transfer)
        {
            var result = _transferService.Add(transfer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(Transfer transfer)
        {
            var result = await _transferService.AddAsync(transfer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("Update")]
        public IActionResult Update(Transfer transfer)
        {
            var result = _transferService.Update(transfer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(Transfer transfer)
        {
            var result = await _transferService.UpdateAsync(transfer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Transfer transfer)
        {
            var result = _transferService.Delete(transfer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(Transfer transfer)
        {
            var result = await _transferService.DeleteAsync(transfer);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}

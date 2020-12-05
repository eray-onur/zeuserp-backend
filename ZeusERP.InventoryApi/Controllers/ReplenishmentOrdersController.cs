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
    public class ReplenishmentOrdersController : ControllerBase
    {
        private IOrderReplenishmentService _replenishmentService;

        public ReplenishmentOrdersController(IOrderReplenishmentService replenishmentService)
        {
            _replenishmentService = replenishmentService;
        }

        [HttpGet("GetAll")]
        public IActionResult Replenishments()
        {
            var result = _replenishmentService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> ReplenishmentsAsync()
        {
            var result = await _replenishmentService.GetListAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetList")]
        public IActionResult GetReplenishmentListDto()
        {
            var result = _replenishmentService.GetReplenishmentListDto();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetListAsync")]
        public async Task<IActionResult> GetReplenishmentListDtoAsync()
        {
            var result = await _replenishmentService.GetReplenishmentListDtoAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetReplenishmentById(int id)
        {
            var result = _replenishmentService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetAsync/{id}")]
        public async Task<IActionResult> GetReplenishmentByIdAsync(int id)
        {
            var result = await _replenishmentService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetDetails/{id}")]
        public IActionResult GetReplenishmentDetailsDtoById(int id)
        {
            var result = _replenishmentService.GetReplenishmentDetailsDtoById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetDetailsAsync/{id}")]
        public async Task<IActionResult> GetReplenishmentDetailsDtoByIdAsync(int id)
        {
            var result = await _replenishmentService.GetReplenishmentDetailsDtoByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(Replenishment replenishment)
        {
            var result = _replenishmentService.Add(replenishment);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(Replenishment replenishment)
        {
            var result = await _replenishmentService.AddAsync(replenishment);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("Update")]
        public IActionResult Update(Replenishment replenishment)
        {
            var result = _replenishmentService.Update(replenishment);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(Replenishment replenishment)
        {
            var result = await _replenishmentService.UpdateAsync(replenishment);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Replenishment replenishment)
        {
            var result = _replenishmentService.Delete(replenishment);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(Replenishment replenishment)
        {
            var result = await _replenishmentService.DeleteAsync(replenishment);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}

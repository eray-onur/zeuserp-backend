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
    public class WarehousesController : ControllerBase
    {
        private IWarehouseService _warehouseService;
        public WarehousesController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }
        [HttpGet("GetAll")]
        public IActionResult Warehouses()
        {
            var result = _warehouseService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> WarehousesAsync()
        {
            var result = await _warehouseService.GetListAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("Get/{id}")]
        public IActionResult GetWarehouseById(int id)
        {
            var result = _warehouseService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetAsync/{id}")]
        public async Task<IActionResult> WarehouseByIdAsync(int id)
        {
            var result = await _warehouseService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetDetails/{id}")]
        public IActionResult WarehouseDetailsDtoById(int id)
        {
            var result = _warehouseService.GetWarehouseDetailsDtoById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetDetailsAsync/{id}")]
        public async Task<IActionResult> WarehouseDetailsDtoByIdAsync(int id)
        {
            var result = await _warehouseService.GetWarehouseDetailsDtoByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetList")]
        public IActionResult WarehouseListDto()
        {
            var result = _warehouseService.GetWarehouseListDto();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetListAsync")]
        public async Task<IActionResult> WarehouseListDtoAsync()
        {
            var result = await _warehouseService.GetWarehouseListDtoAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("Add")]
        public IActionResult Add(Warehouse warehouse)
        {
            var result = _warehouseService.Add(warehouse);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(Warehouse warehouse)
        {
            var result = await _warehouseService.AddAsync(warehouse);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("Update")]
        public IActionResult Update(Warehouse warehouse)
        {
            var result = _warehouseService.Update(warehouse);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(Warehouse warehouse)
        {
            var result = await _warehouseService.UpdateAsync(warehouse);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(Warehouse warehouse)
        {
            var result = _warehouseService.Delete(warehouse);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(Warehouse warehouse)
        {
            var result = await _warehouseService.DeleteAsync(warehouse);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}

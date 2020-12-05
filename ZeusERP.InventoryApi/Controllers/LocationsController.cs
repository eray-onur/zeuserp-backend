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
    public class LocationsController : ControllerBase
    {
        private ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("GetAll")]
        public IActionResult Locations()
        {
            var result = _locationService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> LocationsAsync()
        {
            var result = await _locationService.GetListAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetList")]
        public IActionResult GetLocationListDto()
        {
            var result = _locationService.GetLocationListDto();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetListAsync")]
        public async Task<IActionResult> GetLocationListDtoAsync()
        {
            var result = await _locationService.GetLocationListDtoAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetLocationById(int id)
        {
            var result = _locationService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetAsync/{id}")]
        public async Task<IActionResult> GetLocationByIdAsync(int id)
        {
            var result = await _locationService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetDetails/{id}")]
        public IActionResult GetLocationDetailsDtoById(int id)
        {
            var result = _locationService.GetLocationDetailsDtoById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetDetailsAsync/{id}")]
        public async Task<IActionResult> GetLocationDetailsDtoByIdAsync(int id)
        {
            var result = await _locationService.GetLocationDetailsDtoByIdAsync(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("Add")]
        public IActionResult Add(Location location)
        {
            var result = _locationService.Add(location);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(Location location)
        {
            var result = await _locationService.AddAsync(location);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("Update")]
        public IActionResult Update(Location location)
        {
            var result = _locationService.Update(location);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(Location location)
        {
            var result = await _locationService.UpdateAsync(location);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(Location location)
        {
            var result = _locationService.Delete(location);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(Location location)
        {
            var result = await _locationService.DeleteAsync(location);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}

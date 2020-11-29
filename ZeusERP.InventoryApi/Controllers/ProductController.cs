using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ZeusERP.Business.Abstract;
using ZeusERP.Entities.Concrete;

namespace ZeusERP.InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        [HttpGet("Get/{id}")]
        public IActionResult GetProductById(int id)
        {
            var result = _productService.GetById(id);
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetDetails/{id}")]
        public IActionResult GetProductDetailsById(int id)
        {
            var result = _productService.GetProductDetailsById(id);
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetExtendedList")]
        public IActionResult GetProductList()
        {
            var result = _productService.GetProductListItem();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetExtendedListAsync")]
        public async Task<IActionResult> GetProductListAsync()
        {
            var result = await _productService.GetProductListItemAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetList")]
        public IActionResult Products()
        {
            var result = _productService.GetList();
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetListAsync")]
        public async Task<IActionResult> ProductsAsync()
        {
            var result = await _productService.GetListAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("Add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if(result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("Update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("CreateBoth")]
        public IActionResult CreateBoth()
        {
            using(var transactionScope = new TransactionScope())
            {
                Category cat = new Category
                {
                    Name = "Fixed Asset",
                    Description = "All assets that are used to product income belong to fixed assets.",
                    SubcategoryId = -1
                };
                _categoryService.Add(cat);
                Product prod = new Product
                {
                    Name = "Laptop",
                    Description = "This is a laptop.",
                    Type = Entities.Concrete.Enums.ProductType.Producable
                };
                _productService.Add(prod);
                var fetchedProduct = _productService.GetById(4).Data;
                transactionScope.Complete();
                return Ok();
            }
            
        }
    }
}

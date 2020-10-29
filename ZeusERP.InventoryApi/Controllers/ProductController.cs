using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

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
        [HttpGet("GetAll")]
        public IActionResult Products()
        {
            var result = _productService.GetList();
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> ProductsAsync()
        {
            var result = await _productService.GetListAsync();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetAllWithCategory")]
        public IActionResult ProductsWithCategory()
        {
            var result = _productService.GetProductListWithCategory();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetWithCategories/{id}")]
        public IActionResult ProductsByCategory(int categoryId)
        {
            var result = _productService.GetProductListByCategory(categoryId);
            if(result.Success)
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
                    CategoryName = "Fixed Asset",
                    CategoryDescription = "All assets that are used to product income belong to fixed assets.",
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

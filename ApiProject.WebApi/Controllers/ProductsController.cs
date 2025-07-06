using ApiProject.BusinessLayer.Abstract;
using ApiProject.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductsController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _ProductService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateProduct(Product Product)
        {
            _ProductService.TAdd(Product);
            return Created("Ekleme Basarili", Product);
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product Product)
        {
            _ProductService.TUpdate(Product);
            return Ok("Update Basarili"); // 204 No Content
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _ProductService.TDelete(id);
            return Ok("Silme Basarili"); // 200 OK
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _ProductService.TGetById(id);

            return Ok(value);
        }
    }
}

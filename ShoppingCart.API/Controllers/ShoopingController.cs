using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Models.EntityFramework;
using ShoppingCart.Models.Response;
using ShoppingCart.Repository;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ProducesResponseType(typeof(OkResult<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public class ShoppingController : ControllerBase
    {
        public IShoppingCartRepository repository;
        public ShoppingController(IShoppingCartRepository shopping)
        {
            this.repository = shopping;
        }

        [HttpGet]
        public ActionResult HelloWorld(string Name)
        {
            return Ok(new OkResult<string>(){Data = $"Hello {Name}"});
        }

        [HttpGet]
        public ActionResult GetProducts()
        {
            try
            {
                return Ok(new OkResult<IEnumerable<Product>>(){ Data = this.repository.Get()});
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }

        [HttpPost]
        public ActionResult AddProducts(ProductDetails productDetails)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                            cfg.CreateMap<ProductDetails, Product>());
                var mapper = new Mapper(config);

                Product product = mapper.Map<ProductDetails, Product>(productDetails);
                Product result = this.repository.Add(product);

                return Ok(new OkResult<Product>(){ Data = result});
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }

        [HttpGet]
        public ActionResult GetProduct(int Id)
        {
            try
            {
                return Ok(new OkResult<Product>(){ Data = this.repository.Get(Id)});
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }
    }
}
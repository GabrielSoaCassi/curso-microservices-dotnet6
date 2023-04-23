using GeepShopping.ProductAPI.Data.ValueObjects;
using GeepShopping.ProductAPI.Model;
using GeepShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeepShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> FindById(long id)
        {
            var product = await _productRepository.FindById(id);
            if(product == null) return NotFound();  
                return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> FindAll()
        {
            var products = await _productRepository.FindAll();
            if (products == null) return NotFound();  
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Create(ProductDTO productDTO){
            if(productDTO == null) return BadRequest(); 
            var product = await _productRepository.Create(productDTO);
            return Ok(product);

        }

        [HttpPut]
        public async Task<ActionResult<ProductDTO>> Update(ProductDTO productDTO){
            if(productDTO == null) return BadRequest(); 
            var product = await _productRepository.Update(productDTO);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDTO>> Delete(long id)
        {
            var status = await _productRepository.Delete(id);
            if(!status) return BadRequest(); 
            return Ok(status);
        }

    }
}

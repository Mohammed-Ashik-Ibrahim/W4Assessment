using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using W4Assessment.Model;
using W4Assessment.Repositories;

namespace W4Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _proRepository;

        public ProductsController(IProductsRepository proRepository)

        {
            _proRepository = proRepository;
        }

        
        [HttpGet]

        public async Task<IEnumerable<Products>> GetProducts()

        {

            return await _proRepository.Get();

        }

        [HttpGet("{ProductId}")]

        public async Task<ActionResult<Products>> GetProducts(int ProductId)

        {

            return await _proRepository.Get(ProductId);

        }


        [HttpPost]

        public async Task<ActionResult<Products>> PostProducts([FromBody] Products products)

        {

            var newProducts = await _proRepository.Create(products);

            return CreatedAtAction(nameof(GetProducts), new { ProductId = newProducts.ProductId }, newProducts);

        }


        [HttpPut("{ProductId}")]

        public async Task<ActionResult> PutProducts(int ProductId, [FromBody] Products products)

        {


            if (ProductId != products.ProductId)

            {

                return BadRequest();

            }

            await _proRepository.Update(products);

            return NoContent();

        }


        [HttpDelete("{ProductId}")]

        public async Task<ActionResult> Delete(int ProductId)

        {

            var productDelete = await _proRepository.Get(ProductId);

            if (productDelete == null)

                return NotFound();

            await _proRepository.Delete(productDelete.ProductId);

            return NoContent();

        }

    }
}


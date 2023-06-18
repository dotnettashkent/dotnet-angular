using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext appDbcontext;

        public ProductsController(AppDbContext appDbcontext)
        {
            this.appDbcontext = appDbcontext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products = await appDbcontext.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            return await appDbcontext.Products.FindAsync(id);
        }

    }
}

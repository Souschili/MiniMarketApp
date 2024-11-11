using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniMarket.Domain.Repositories.Contract;

namespace MiniMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _repo;
        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var prod=await _repo.GetAllAsync();
            return Ok(prod);
        }
    }
}

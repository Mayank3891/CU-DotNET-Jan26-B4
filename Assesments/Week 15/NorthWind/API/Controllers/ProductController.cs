using API.DTO;
using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("by-category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var data = await _repo.GetByCategoryIdAsync(categoryId);
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(data));
        }

        
    }
}

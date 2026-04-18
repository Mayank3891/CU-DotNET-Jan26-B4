
using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _repo.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CategoryDto>>(data);
            return Ok(result);
        }
    }
}
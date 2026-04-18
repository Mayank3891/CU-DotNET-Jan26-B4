using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public SummaryController(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary()
        {
            var data = await _repo.GetCategorySummariesAsync();
            return Ok(data);
        }

    }
}

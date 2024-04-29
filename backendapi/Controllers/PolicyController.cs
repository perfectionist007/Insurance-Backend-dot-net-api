using AutoMapper;
using backendapi.Core.Context;
using backendapi.Core.Dtos.Policy;
using backendapi.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backendapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }

        public PolicyController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // CRUD 

        // Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreatePolicy([FromBody] PolicyCreateDto dto)
        {
            var newPolicy = _mapper.Map<Policy>(dto);
            await _context.Policies.AddAsync(newPolicy);
            await _context.SaveChangesAsync();

            return Ok("Policy Created Successfully");
        }

        // Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<PolicyGetDto>>> GetPolicies()
        {
            var policies = await _context.Policies.Include(policy => policy.Category).OrderByDescending(q => q.CreatedAt).ToListAsync();
            var convertdPolicies = _mapper.Map<IEnumerable<PolicyGetDto>>(policies);

            return Ok(convertdPolicies);
        }

        // Read (Get Policy By ID)

        // Update 

        // Delete
    }
}

using AutoMapper;
using backendapi.Core.Context;
using backendapi.Core.Dtos.Category;
using backendapi.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backendapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }

        public CategoryController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // CRUD 

        // Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto dto)
        {
            Category newCategory = _mapper.Map<Category>(dto);
            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            return Ok("Category Created Successfully");
        }

        // Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CategoryGetDto>>> GetCategories()
        {
            var categories = await _context.Categories.OrderByDescending(q => q.CreatedAt).ToListAsync();
            var convertedCategories = _mapper.Map<IEnumerable<CategoryGetDto>>(categories);

            return Ok(convertedCategories);
        }

        // Read (Get Category By ID)

        // Update 

        // Delete

    }
}

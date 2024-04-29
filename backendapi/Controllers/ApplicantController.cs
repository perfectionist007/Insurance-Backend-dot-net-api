using AutoMapper;
using backendapi.Core.Context;
using backendapi.Core.Dtos.Applicant;
using backendapi.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backendapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private ApplicationDbContext _context { get; }
        private IMapper _mapper { get; }

        public ApplicantController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // CRUD 

        // Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateApplicant([FromForm] ApplicantCreateDto dto, IFormFile pdfFile)
        {
            // Firt => Save pdf to Server
            // Then => save url into our entity
            var fiveMegaByte = 5 * 1024 * 1024;
            var pdfMimeType = "application/pdf";

            if (pdfFile.Length > fiveMegaByte || pdfFile.ContentType != pdfMimeType)
            {
                return BadRequest("File is not valid");
            }

            var resumeUrl = Guid.NewGuid().ToString() + ".pdf";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdfs", resumeUrl);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream);
            }
            var newApplicant = _mapper.Map<Applicant>(dto);
            newApplicant.ResumeUrl = resumeUrl;
            await _context.Applicants.AddAsync(newApplicant);
            await _context.SaveChangesAsync();

            return Ok("Applicant Saved Successfully");
        }

        // Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<ApplicantGetDto>>> GetApplicants()
        {
            var applicants = await _context.Applicants.Include(c => c.Policy).OrderByDescending(q => q.CreatedAt).ToListAsync();
            var convertedApplicants = _mapper.Map<IEnumerable<ApplicantGetDto>>(applicants);

            return Ok(convertedApplicants);
        }

        // Read (Download Pdf File)
        [HttpGet]
        [Route("download/{url}")]
        public IActionResult DownloadPdfFile(string url)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdfs", url);

            if(!System.IO.File.Exists(filePath))
            {
                return NotFound("File Not Found");
            }

            var pdfBytes = System.IO.File.ReadAllBytes(filePath);
            var file = File(pdfBytes, "application/pdf", url);
            return file;
        }

        // Read (Get Applicant By ID)

        // Update 

        // Delete
    }
}

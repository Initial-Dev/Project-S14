using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S14_API.Data;
using S14_API.Models;
using S14_API.Models.DTO;

namespace S14_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeachersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }

        [HttpGet("{id}/subjects")]
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetSubjectsByTeacher(int id)
        {
            var subjects = await _context.Subjects
                .Where(s => s.TeacherId == id)
                .Select(s => new SubjectDto { Name = s.Name })
                .ToListAsync();

            if (!subjects.Any())
            {
                return NotFound();
            }

            return Ok(subjects);
        }



        [HttpGet("subjects")]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachersAndSubjects()
        {
            return await _context.Teachers.Include(t => t.Subjects).ToListAsync();
        }

        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }
}

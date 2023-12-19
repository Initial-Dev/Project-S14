using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using S14_API.Data;
using S14_API.Models;
using Microsoft.AspNetCore.Authorization;

namespace S14_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AcademicClassesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AcademicClassesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicClass>>> GetAcademicClasses()
        {
            var academicClasses = await _context.AcademicClasses
                .Include(ac => ac.HeadTeacher)
                .ToListAsync();

            return academicClasses;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicClass>> GetAcademicClass(int id)
        {
            var academicClass = await _context.AcademicClasses
                .Include(ac => ac.HeadTeacher)
                .Include(ac => ac.Students)
                .FirstOrDefaultAsync(ac => ac.Id == id);

            if (academicClass == null)
            {
                return NotFound();
            }

            return academicClass;
        }

        [HttpPut("{id}/addStudent/{studentId}")]
        public async Task<IActionResult> UpdateStudentAcademicClass(int studentId, int id)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
            {
                return NotFound("Student not found.");
            }

            var academicClassExists = await _context.AcademicClasses.AnyAsync(ac => ac.Id == id);
            if (!academicClassExists)
            {
                return NotFound("Academic class not found.");
            }

            student.AcademicClassId = id;
            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(studentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }


        private bool AcademicClassExists(int id)
        {
            return _context.AcademicClasses.Any(e => e.Id == id);
        }
    }

}

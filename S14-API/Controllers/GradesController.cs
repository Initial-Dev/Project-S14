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
    public class GradesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GradesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGrades()
        {
            return await _context.Grades.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> GetGrade(int id)
        {
            var grade = await _context.Grades.FindAsync(id);

            if (grade == null)
            {
                return NotFound();
            }

            return grade;
        }

        [HttpGet("student/{studentId}")]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGradesByStudent(int studentId)
        {
            var grades = await _context.Grades
                                       .Where(grade => grade.StudentId == studentId)
                                       .Include(grade => grade.Subject)
                                       .Include(grade => grade.Teacher)
                                       .ToListAsync();

            if (!grades.Any())
            {
                return NotFound();
            }

            return grades;
        }


        [HttpPost]
        public async Task<ActionResult<Grade>> PostGrade(Grade grade)
        {
            if (grade.Value < 0 || grade.Value > 20)
            {
                return BadRequest("Grade must be between 0 and 20.");
            }
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrade", new { id = grade.Id }, grade);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrade(int id, Grade grade)
        {
            if (id != grade.Id)
            {
                return BadRequest();
            }

            if (grade.Value < 0 || grade.Value > 20)
            {
                return BadRequest("Grade must be between 0 and 20.");
            }

            _context.Entry(grade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }

            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("student/subjects/{studentId}")]
        public async Task<ActionResult<IEnumerable<GradeDTO>>> GetStudentGradesBySubject(int studentId, int subjectId)
        {
            var grades = await _context.Grades
            .Include(grade => grade.Subject)
            .Where(grade => grade.StudentId == studentId)
            .Select(grade => new GradeDTO
            {
                StudentId = grade.StudentId,
                TeacherId = grade.TeacherId,
                SubjectId = grade.Subject.Id,
                GradeValue = grade.Value,
            })
            .ToListAsync();

            return Ok(grades);
        }

        private bool GradeExists(int id)
        {
            return _context.Grades.Any(e => e.Id == id);
        }
    }
}

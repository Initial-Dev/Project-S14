using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using S14_API.Data;
using S14_API.Models;
using Microsoft.AspNetCore.Authorization;
using S14_API.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace S14_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        private readonly IPasswordHasher<Student> _passwordHasher;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
        {
            var students = await _context.Students
                                         .Include(s => s.AcademicClass)
                                         .Select(s => new StudentDTO
                                         {
                                             Id = s.Id,
                                             LastName = s.LastName,
                                             FirstName = s.FirstName,
                                             Gender = s.Gender,
                                             AcademicClass = new AcademicClassDTO
                                             {
                                                 Id = s.AcademicClass.Id,
                                                 Level = s.AcademicClass.Level
                                             }
                                         })
                                         .ToListAsync();

            return Ok(students);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpGet("academicClass/{academicClassId}")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsByAcademicClass(int academicClassId)
        {
            var academicClassWithStudents = await _context.AcademicClasses
                .Include(ac => ac.Students)
                .FirstOrDefaultAsync(ac => ac.Id == academicClassId);

            if (academicClassWithStudents == null)
            {
                return NotFound();
            }

            return Ok(academicClassWithStudents.Students);
        }


        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(StudentDTO studentDto)
        {
            var student = new Student
            {
                LastName = studentDto.LastName,
                FirstName = studentDto.FirstName,
                Gender = studentDto.Gender,
                Username = studentDto.Username,
                Password = studentDto.Password,
            };

            _passwordHasher.HashPassword(student, student.Password);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }


        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }

        private bool StudentExistsByUsername(string username)
        {
            return _context.Students.Any(e => e.Username == username);
        }
    }
}
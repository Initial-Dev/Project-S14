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
    [Authorize]
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
            return await _context.AcademicClasses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicClass>> GetAcademicClass(int id)
        {
            var academicClass = await _context.AcademicClasses.FindAsync(id);

            if (academicClass == null)
            {
                return NotFound();
            }

            return academicClass;
        }

        [HttpPost]
        public async Task<ActionResult<AcademicClass>> PostAcademicClass(AcademicClass academicClass)
        {
            _context.AcademicClasses.Add(academicClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcademicClass", new { id = academicClass.Id }, academicClass);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicClass(int id, AcademicClass academicClass)
        {
            if (id != academicClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(academicClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicClassExists(id))
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
        public async Task<IActionResult> DeleteAcademicClass(int id)
        {
            var academicClass = await _context.AcademicClasses.FindAsync(id);
            if (academicClass == null)
            {
                return NotFound();
            }

            _context.AcademicClasses.Remove(academicClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcademicClassExists(int id)
        {
            return _context.AcademicClasses.Any(e => e.Id == id);
        }
    }

}

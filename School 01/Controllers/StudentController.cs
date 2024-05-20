using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_01.Data;
using School_01.Models;

namespace School_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudent()
        {
            var data = await _db.Student.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{StudentId}")]
        public async Task<ActionResult<List<Student>>> GetStudentById(int Id)
        {
            var data = await _db.Student.FindAsync(Id);
            if (data == null)
            {
                return NotFound();
            }


            return Ok(data);
        }

        [HttpPost("AddNew")]
        public async Task<IActionResult> Create(Student obj)
        {
            try
            {
                _db.Student.Add(obj);
                await _db.SaveChangesAsync();
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Student obj)
       
        {
            if (obj == null || obj.Id == 0)
                return BadRequest();

            var product = await _db.Student.FindAsync(obj.Id);
            if (product == null)
                return NotFound();
            product.Name = obj.Name;
            product.CNIC = obj.CNIC;
            product.Gender = obj.Gender;
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("DeleteStudent")]
        public async Task<ActionResult> Delete(int Id)
        {
            var data = await _db.Student.FindAsync(Id);
            if (data == null)
            {
                return NotFound();
            }
            _db.Student.Remove(data);
            await _db.SaveChangesAsync();
            return Ok();
        }

    }
}

using ASP.NETCoreWebAPISandbox.DTO;
using ASP.NETCoreWebAPISandbox.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebAPISandbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentService studentService, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudents() {
            try
            {
                return Ok(await _studentService.GetAllStudentsAsync());
            } catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all students");
                return StatusCode(500, "Something went wrong on the server.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudentById(int id)
        {
            try
            {
                var student = await _studentService.GetStudentByIdAsync(id);

                if (student == null)
                {
                    return NotFound(new { message = $"Student with ID {id} not found." });
                }

                return Ok(student);
            } catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving student {StudentId}", id);
                return StatusCode(500, "Something went wrong on the server.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent([FromBody] StudentDTO studentDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdStudent = await _studentService.AddStudentAsync(studentDTO);


                return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.Id }, createdStudent);
            } catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating student");
                return StatusCode(500, "Something went wrong on the server.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(int id,[FromBody] StudentDTO studentDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedStudent = await _studentService.UpdateStudentAsync(id, studentDTO);

                if(updatedStudent == null)
                {
                    return NotFound(new { message = $"Student with ID {id} not found." });
                }

                return Ok(updatedStudent);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error occurred while updating student {StudentId}", id);
                return StatusCode(500, "Something went wrong on the server.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            try
            {
                var deleted = await _studentService.DeleteStudentAsync(id);

                if(!deleted)
                {
                    return NotFound(new { message = $"Student with ID {id} not found." });
                }

                return NoContent();
            } catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting student {StudentId}", id);
                return StatusCode(500, "Something went wrong on the server.");
            }
        }
    }
}

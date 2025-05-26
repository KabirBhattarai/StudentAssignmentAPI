using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAssignmentAPI.Constrains.Request;
using StudentAssignmentAPI.Data;
using StudentAssignmentAPI.Entities;
using StudentAssignmentAPI.Repositories.Interfaces;
using StudentAssignmentAPI.Services.Interfaces;


namespace StudentAssignmentAPI.Controllers;

[Route("api/students")]

[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;
    private readonly IStudentService _studentService;
    private readonly ApplicationDbContext _context;
    private readonly ILogger<StudentController> _logger;

    public StudentController(IStudentRepository studentRepository, IStudentService studentService, ApplicationDbContext context, ILogger<StudentController> logger)
    {
        _studentRepository = studentRepository;
        _studentService = studentService;
        _context = context;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] StudentRequestDto dto)
    {
        try
        {
            _logger.LogInformation("Creating student");
            var student = await _studentService.AddStudentAsync(dto);
            _logger.LogInformation("Student created successfully {studentId}", student.Id);
            return Ok(new { message = "Student created successfully", id = student.Id });

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while creating student");
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] StudentRequestDto dto)
    {
        try
        {
            _logger.LogInformation("Updating student");
            var student = await _studentService.UpdateStudentAsync(id, dto);
            return Ok(new { message = "Student updated successfully", id = student.Id });

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while updating student");
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        try
        {
            _logger.LogInformation("Deleting student");
            await _studentService.DeleteStudentAsync(id);
            return Ok(new { message = "Student deleted successfully" });

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while deleting student");
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            _logger.LogInformation("Getting all students");
            var students = await _studentRepository.GetStudentsAsync();
            return Ok(new { message = "Students retrieved successfully", data = students });

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting all students");
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            _logger.LogInformation("Getting student");
            var student = await _studentRepository.GetStudentByIdAsync(id);
            return Ok(new { message = "Student retrieved successfully", data = student });

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting student");
            return BadRequest(e.Message);
        }
    }
}
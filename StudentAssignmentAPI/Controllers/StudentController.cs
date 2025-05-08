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

    public StudentController(IStudentRepository studentRepository, IStudentService studentService, ApplicationDbContext context)
    {
        _studentRepository = studentRepository;
        _studentService = studentService;
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult> CreateStudent([FromBody] StudentRequestDto dto)
    {
        try
        {
            var student = await _studentService.AddStudentAsync(dto);
            return Ok(new { message = "Student created successfully", id = student.Id });

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateStudent(Guid id, [FromBody] StudentRequestDto dto)
    {
        try
        {
            var student = await _studentService.UpdateStudentAsync(id, dto);
            return Ok(new { message = "Student updated successfully", id = student.Id });

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteStudent(Guid id)
    {
        try
        {
            await _studentService.DeleteStudentAsync(id);
            return Ok(new { message = "Student deleted successfully" });

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
        try
        {
            var students = await _studentRepository.GetStudentsAsync();
            return Ok(new { message = "Students retrieved successfully", data = students });

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudentById(Guid id)
    {
        try
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            return Ok(new { message = "Student retrieved successfully", data = student });

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
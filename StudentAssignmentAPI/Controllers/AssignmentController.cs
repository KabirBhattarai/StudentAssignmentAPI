using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAssignmentAPI.Constrains.Request;
using StudentAssignmentAPI.Data;
using StudentAssignmentAPI.Entities;
using StudentAssignmentAPI.Repositories.Interfaces;
using StudentAssignmentAPI.Services.Interfaces;

namespace StudentAssignmentAPI.Controllers;

[Route("api/assignments")]
[Authorize]
[ApiController]
[Authorize]
public class AssignmentController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IAssignmentService _assignmentService;
    private readonly IAssignmentRepository _assignmentRepository;
    
    private readonly ILogger<AssignmentController> _logger;


    public AssignmentController(ApplicationDbContext context, IAssignmentService assignmentService,
        IAssignmentRepository assignmentRepository, ILogger<AssignmentController> logger)
    {
        _context = context;
        _assignmentService = assignmentService;
        _assignmentRepository = assignmentRepository;
        _logger = logger;
    }


    [HttpPost]
    public async Task<IActionResult> CreateAssignment([FromBody] AssignmentRequestDto dto)
    {
        try
        {
            _logger.LogInformation("Creating assignment");
            
            var assignment = await _assignmentService.AddAssignmentAsync(dto);
            
            _logger.LogInformation("Assignment created successfully {assignmentId}", assignment.Id);
            
            return Ok(new { message = "Assignment created successfully" });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while creating assignment");
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAssignment(Guid id, [FromBody] AssignmentRequestDto dto)
    {
        try
        {
            var assignment = await _assignmentService.UpdateAssignmentAsync(id, dto);
            return Ok(new { message = "Assignment updated successfully" });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAssignment(Guid id)
    {
        try
        {
            await _assignmentService.DeleteAssignmentAsync(id);
            return Ok(new { message = "Assignment deleted successfully" });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAssignments()
    {
        try
        {
            var assignments = await _assignmentRepository.GetAllAssignmentsAsync();
            return Ok(new { message = "Assignment retrieved successfully", assignments = assignments });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAssignmentById(Guid id)
    {
        try
        {
            var assignment = await _assignmentRepository.GetAssignmentByIdAsync(id);
            return Ok(new { message = "Assignment retrieved successfully" });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
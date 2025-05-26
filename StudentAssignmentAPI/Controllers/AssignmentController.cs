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

[ApiController]

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
    public async Task<IActionResult> Create([FromBody] AssignmentRequestDto dto)
    {
        try
        {
            _logger.LogInformation("Creating assignment");
            
            var assignment = await _assignmentService.AddAssignmentAsync(dto);
            
            _logger.LogInformation("Assignment created successfully {assignmentId}", assignment.Id);
            
            return Ok(new { message = "Assignment created successfully", data = assignment });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while creating assignment");
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] AssignmentRequestDto dto)
    {
        try
        {
            _logger.LogInformation("Updating assignment");
            var assignment = await _assignmentService.UpdateAssignmentAsync(id, dto);
            return Ok(new { message = "Assignment updated successfully", data = assignment });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while updating assignment");
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            _logger.LogInformation("Deleting assignment");
            await _assignmentService.DeleteAssignmentAsync(id);
            return Ok(new { message = "Assignment deleted successfully" });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while deleting assignment");
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            _logger.LogInformation("Getting assignments");
            var assignments = await _assignmentRepository.GetAllAssignmentsAsync();
            return Ok(new { message = "Assignment retrieved successfully", data = assignments });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting assignments");
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            _logger.LogInformation("Getting the assignment");
            var assignment = await _assignmentRepository.GetAssignmentByIdAsync(id);
            return Ok(new { message = "Assignment retrieved successfully", data = assignment });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting the assignment");
            return BadRequest(e.Message);
        }
    }
}
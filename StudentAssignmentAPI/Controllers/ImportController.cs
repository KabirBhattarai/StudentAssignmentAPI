using Hangfire;
using Microsoft.AspNetCore.Mvc;
using StudentAssignmentAPI.Dtos;
using StudentAssignmentAPI.Services;
using StudentAssignmentAPI.Services.Interfaces;

namespace StudentAssignmentAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BulkController : ControllerBase
{
    private readonly IBulkJobService _bulkJobService;

    public BulkController(IBulkJobService bulkJobService)
    {
        _bulkJobService = bulkJobService;
    }

    [HttpPost("import-students")]
    public IActionResult ImportStudents([FromBody] BulkStudentDto dto)
    {
        var jobId = BackgroundJob.Enqueue<IBulkJobService>(x => x.ImportStudentsAsync(dto.Students));

        // OK = completed. It will respond 200. ❌
        // Working on it = 202. It will respond 202. ✅

        return Accepted(new
        {
            JobId = jobId,
            Status = "Queued"
        });
    }

    public IActionResult Check(string jobId)
    {
        try
        {
            var jobState = JobStorage.Current.GetMonitoringApi().JobDetails(jobId);
            if (jobState == null)
            {
                return NotFound(new { Message = "Job not found" });
            }

            // states are "Enqueued", "Processing", "Succeeded", "Failed", etc.
            var state = jobState.History.FirstOrDefault()?.StateName;
            return Ok(new
            {
                JobId = jobId,
                Status = state
            });
        }
        catch (Exception e)
        {
            return BadRequest(new { Message = "Error retrieving job status", Error = e.Message });
        }
    }

    [HttpPost("import-assignments")]
    public IActionResult ImportAssignments([FromBody] BulkAssignmentDto dto)
    {
        var jobId = BackgroundJob.Enqueue(() => _bulkJobService.ImportAssignmentsAsync(dto.Assignments));
        return Ok(new { JobId = jobId, Status = "Queued" });
    }
}
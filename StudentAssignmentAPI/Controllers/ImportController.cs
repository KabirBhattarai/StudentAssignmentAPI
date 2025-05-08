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
            var jobId = BackgroundJob.Enqueue(() => _bulkJobService.ImportStudentsAsync(dto.Students));
            return Ok(new { JobId = jobId, Status = "Queued" });
        }

        [HttpPost("import-assignments")]
        public IActionResult ImportAssignments([FromBody] BulkAssignmentDto dto)
        {
            var jobId = BackgroundJob.Enqueue(() => _bulkJobService.ImportAssignmentsAsync(dto.Assignments));
            return Ok(new { JobId = jobId, Status = "Queued" });
        }
    }

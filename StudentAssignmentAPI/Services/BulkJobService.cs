using StudentAssignmentAPI.Constrains.Request;
using StudentAssignmentAPI.Services.Interfaces;

namespace StudentAssignmentAPI.Services;

public class BulkJobService: IBulkJobService
{
    private readonly IStudentService _studentService;
    private readonly IAssignmentService _assignmentService;

    public BulkJobService(IStudentService studentService, IAssignmentService assignmentService)
    {
        _studentService = studentService;
        _assignmentService = assignmentService;
    }

    public async Task ImportStudentsAsync(List<StudentRequestDto> students)
    {
        foreach (var student in students)
        {
            await _studentService.AddStudentAsync(student);
        }
    }

    public async Task ImportAssignmentsAsync(List<AssignmentRequestDto> assignments)
    {
        foreach (var assignment in assignments)
        {
            await _assignmentService.AddAssignmentAsync(assignment);
        }
    }
}
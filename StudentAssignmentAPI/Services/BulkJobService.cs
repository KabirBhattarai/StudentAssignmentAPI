using System.Transactions;
using StudentAssignmentAPI.Constrains.Request;
using StudentAssignmentAPI.Services.Interfaces;

namespace StudentAssignmentAPI.Services;

public class BulkJobService : IBulkJobService
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
        // Either all or nothing
        // Atomic operation, if one fails, all fail
        // Solution 1: Use a transaction, Unit of work
        
        
        // Use a transaction scope if you are working with multiple upserts.

        // request Items : 200.
        // Success : 180. ->
        // Failed : 20.

        // User will be notified that the import is incomplete or failed

        using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        foreach (var student in students)
        {
            await _studentService.AddStudentAsync(student);
        }

        scope.Complete(); // If this line is not reached, the transaction will be rolled back
    }

    public async Task ImportAssignmentsAsync(List<AssignmentRequestDto> assignments)
    {
        foreach (var assignment in assignments)
        {
            await _assignmentService.AddAssignmentAsync(assignment);
        }
    }
}
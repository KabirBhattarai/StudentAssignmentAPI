using StudentAssignmentAPI.Constrains.Request;

namespace StudentAssignmentAPI.Services.Interfaces;

public interface IBulkJobService
{
    public Task ImportStudentsAsync(List<StudentRequestDto> students);
    public Task ImportAssignmentsAsync(List<AssignmentRequestDto> assignments);
}
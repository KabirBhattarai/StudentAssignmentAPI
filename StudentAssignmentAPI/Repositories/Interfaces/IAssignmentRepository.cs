using StudentAssignmentAPI.Constrains.Response;

namespace StudentAssignmentAPI.Repositories.Interfaces;

public interface IAssignmentRepository
{
    Task<List<AssignmentResponseDto>> GetAllAssignmentsAsync();
    Task<AssignmentResponseDto?> GetAssignmentByIdAsync(Guid id);
}
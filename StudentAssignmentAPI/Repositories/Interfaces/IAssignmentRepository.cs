using StudentAssignmentAPI.Constrains.Response;
using StudentAssignmentAPI.Entities;
using StudentAssignmentAPI.GenericRepo;

namespace StudentAssignmentAPI.Repositories.Interfaces;

public interface IAssignmentRepository : IGenericRepo<Assignment>
{
    Task<List<AssignmentResponseDto>> GetAllAssignmentsAsync();
    Task<AssignmentResponseDto?> GetAssignmentByIdAsync(Guid id);
}
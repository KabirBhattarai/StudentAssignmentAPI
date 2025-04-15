using StudentAssignmentAPI.Constrains.Request;
using StudentAssignmentAPI.Entities;

namespace StudentAssignmentAPI.Services.Interfaces;

public interface IAssignmentService
{
    Task<Assignment> AddAssignmentAsync(AssignmentRequestDto dto);
    Task<Assignment> UpdateAssignmentAsync(Guid id, AssignmentRequestDto dto);
    Task DeleteAssignmentAsync(Guid id);
    
}
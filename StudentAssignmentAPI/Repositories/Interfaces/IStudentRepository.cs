using StudentAssignmentAPI.Constrains.Response;

namespace StudentAssignmentAPI.Repositories.Interfaces;

public interface IStudentRepository
{
    Task<List<StudentResponseDto>> GetStudentsAsync();
    Task<StudentResponseDto?> GetStudentByIdAsync(Guid id);
}
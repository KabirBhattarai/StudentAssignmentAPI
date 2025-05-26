using StudentAssignmentAPI.Constrains.Response;
using StudentAssignmentAPI.Entities;
using StudentAssignmentAPI.GenericRepo;

namespace StudentAssignmentAPI.Repositories.Interfaces;

public interface IStudentRepository : IGenericRepo<Student>
{
    Task<List<StudentResponseDto>> GetStudentsAsync();
    Task<StudentResponseDto?> GetStudentByIdAsync(Guid id);
}
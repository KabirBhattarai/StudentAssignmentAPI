using StudentAssignmentAPI.Constrains.Request;
using StudentAssignmentAPI.Entities;

namespace StudentAssignmentAPI.Services.Interfaces;

public interface IStudentService
{
    Task<Student> AddStudentAsync(StudentRequestDto dto);
    Task<Student> UpdateStudentAsync(Guid id, StudentRequestDto dto);
    Task DeleteStudentAsync(Guid id);
    
}
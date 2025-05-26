using StudentAssignmentAPI.Constrains.Request;
using StudentAssignmentAPI.Entities;
using StudentAssignmentAPI.Repositories.Interfaces;
using StudentAssignmentAPI.Services.Interfaces;

namespace StudentAssignmentAPI.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Student> AddStudentAsync(StudentRequestDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.FullName))
        {
            throw new Exception("Full Name is required");
        }

        var student = new Student
        {
            FullName = dto.FullName,
            Email = dto.Email
        };

        await _studentRepository.AddAsync(student);
        return student;
    }

    public async Task<Student> UpdateStudentAsync(Guid id, StudentRequestDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.FullName))
        {
            throw new Exception("Full Name is required");
        }

        var student = await _studentRepository.GetByIdAsync(id);
        if (student == null)
        {
            throw new Exception("Student not found");
        }

        student.FullName = dto.FullName;
        student.Email = dto.Email;

        await _studentRepository.UpdateAsync(student);
        return student;
    }

    public async Task DeleteStudentAsync(Guid id)
    {
        await _studentRepository.DeleteAsync(id);
    }
}
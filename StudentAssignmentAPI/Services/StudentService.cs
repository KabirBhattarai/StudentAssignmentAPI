using StudentAssignmentAPI.Constrains.Request;
using StudentAssignmentAPI.Data;
using StudentAssignmentAPI.Entities;
using StudentAssignmentAPI.Services.Interfaces;

namespace StudentAssignmentAPI.Services;

public class StudentService : IStudentService
{
    private readonly ApplicationDbContext _context;

    public StudentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Student> AddStudentAsync(StudentRequestDto dto)
    {
        var student = new Student
        {
            FullName = dto.FullName,
            Email = dto.Email
        };
        
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }

    public async Task<Student> UpdateStudentAsync(Guid id, StudentRequestDto dto)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            throw new Exception("Student not found");
        }
        
        student.FullName = dto.FullName;
        student.Email = dto.Email;
        await _context.SaveChangesAsync();
        return student;
        
    }

    public async Task DeleteStudentAsync(Guid id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            throw new Exception("Student not found");
        }
        
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
    }
}
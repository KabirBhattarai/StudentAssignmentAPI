using Microsoft.EntityFrameworkCore;
using StudentAssignmentAPI.Constrains.Response;
using StudentAssignmentAPI.Data;
using StudentAssignmentAPI.Entities;
using StudentAssignmentAPI.GenericRepo;
using StudentAssignmentAPI.Repositories.Interfaces;

namespace StudentAssignmentAPI.Repositories;


public class StudentRepository : GenericRepo<Student>, IStudentRepository
{
    private readonly ApplicationDbContext _context;

    public StudentRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<StudentResponseDto>> GetStudentsAsync()
    {
        var students = await _context.Students
            .Select(s => new StudentResponseDto
            {
                Id = s.Id,
                Email = s.Email,
                FullName = s.FullName
            })
            .ToListAsync();

        return students;
    }

    public async Task<StudentResponseDto?> GetStudentByIdAsync(Guid id)
    {
        var student = await _context.Students
            .Where(s => s.Id == id)
            .Select(s => new StudentResponseDto
            {
                Id = s.Id,
                Email = s.Email,
                FullName = s.FullName
            })
            .FirstOrDefaultAsync();

        if (student == null)
        {
            throw new Exception("Student not found");
        }

        return student;
    }
}
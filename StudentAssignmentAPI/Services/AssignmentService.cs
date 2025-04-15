using StudentAssignmentAPI.Constrains.Request;
using StudentAssignmentAPI.Data;
using StudentAssignmentAPI.Entities;
using StudentAssignmentAPI.Services.Interfaces;

namespace StudentAssignmentAPI.Services;

public class AssignmentService : IAssignmentService
{
    private readonly ApplicationDbContext _context;

    public AssignmentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Assignment> AddAssignmentAsync(AssignmentRequestDto dto)
    {
        var assignment = new Assignment
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate,
            StudentId = dto.StudentId

        };
        await _context.Assignments.AddAsync(assignment);
        await _context.SaveChangesAsync();
        return assignment;
    }

    public async Task<Assignment> UpdateAssignmentAsync(Guid id, AssignmentRequestDto dto)
    {
        var assignment = await _context.Assignments.FindAsync(id);
        if (assignment == null)
        {
            throw new Exception("Assignment not found");
        }
        assignment.Title = dto.Title;
        assignment.Description = dto.Description;
        assignment.DueDate = dto.DueDate;
        assignment.StudentId = dto.StudentId;
        await _context.SaveChangesAsync();
        return assignment;
    }

    public async Task DeleteAssignmentAsync(Guid id)
    {
        var assignment = await _context.Assignments.FindAsync(id);
        if (assignment == null)
        {
            throw new Exception("Assignment not found");
        }
        _context.Assignments.Remove(assignment);
        await _context.SaveChangesAsync();
    }
}
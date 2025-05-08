using StudentAssignmentAPI.Constrains.Request;
using StudentAssignmentAPI.Data;
using StudentAssignmentAPI.Entities;
using StudentAssignmentAPI.Repositories.Interfaces;
using StudentAssignmentAPI.Services.Interfaces;

namespace StudentAssignmentAPI.Services;

public class AssignmentService : IAssignmentService
{
    private readonly IAssignmentRepository _assignmentRepository;

    public AssignmentService(IAssignmentRepository assignmentRepository)
    {
        _assignmentRepository = assignmentRepository;
    }

    public async Task<Assignment> AddAssignmentAsync(AssignmentRequestDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
        {
            throw new Exception("Title is required");
        }
        
        var assignment = new Assignment
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate,
            StudentId = dto.StudentId

        };
        
        await _assignmentRepository.AddAsync(assignment);
        return assignment;
    }

    public async Task<Assignment> UpdateAssignmentAsync(Guid id, AssignmentRequestDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
        {
            throw new Exception("Title is required");
        }
        
        //var assignment = await _context.Assignments.FindAsync(id);
        var assignment = await _assignmentRepository.GetByIdAsync(id);
        
        if (assignment == null)
        {
            throw new Exception("Assignment not found");
        }
        assignment.Title = dto.Title;
        assignment.Description = dto.Description;
        assignment.DueDate = dto.DueDate;
        assignment.StudentId = dto.StudentId;
        
        //await _context.SaveChangesAsync();
        await _assignmentRepository.UpdateAsync(assignment);
        return assignment;
    }

    // To make it extensible
    public async Task DeleteAssignmentAsync(Guid id)
    {
        await _assignmentRepository.DeleteAsync(id);
    }
}
﻿using Microsoft.EntityFrameworkCore;
using StudentAssignmentAPI.Constrains.Response;
using StudentAssignmentAPI.Data;
using StudentAssignmentAPI.Entities;
using StudentAssignmentAPI.GenericRepo;
using StudentAssignmentAPI.Repositories.Interfaces;

namespace StudentAssignmentAPI.Repositories;


// Assignment repo is inheriting from the generic repo
public class AssignmentRepository : GenericRepo<Assignment>, IAssignmentRepository
{
    private readonly ApplicationDbContext _context;

    public AssignmentRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<AssignmentResponseDto>> GetAllAssignmentsAsync()
    {
        var assignments = await _context.Assignments
            .Select(a => new AssignmentResponseDto
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                DueDate = a.DueDate,
                StudentId = a.StudentId,
                IsSubmitted = a.IsSubmitted
            })
            .ToListAsync();
        return assignments;
    }

    public async Task<AssignmentResponseDto?> GetAssignmentByIdAsync(Guid id)
    {
        var assignment = await _context.Assignments
            .Where(a => a.Id == id)
            .Select(a => new AssignmentResponseDto
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                DueDate = a.DueDate,
                StudentId = a.StudentId,
                IsSubmitted = a.IsSubmitted
            })
            .FirstOrDefaultAsync();
        if (assignment == null)
        {
            throw new Exception("Assignment not found");
        }

        return assignment;
    }
}
using Microsoft.EntityFrameworkCore;
using StudentAssignmentAPI.Entities;

namespace StudentAssignmentAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<Student> Students { get; set; }
    
}
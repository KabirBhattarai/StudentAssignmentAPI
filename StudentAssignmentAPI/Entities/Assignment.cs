using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentAssignmentAPI.Entities;

public class Assignment
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsSubmitted { get; set; }
    public Guid StudentId { get; set; }
    public virtual Student Student { get; set; }
}
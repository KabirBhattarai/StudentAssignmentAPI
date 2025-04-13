namespace StudentAssignmentAPI.Constrains.Response;

public class AssignmentResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsSubmitted { get; set; }
    public Guid StudentId { get; set; }
}
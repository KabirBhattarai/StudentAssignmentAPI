namespace StudentAssignmentAPI.Constrains.Request;

public class AssignmentRequestDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsSubmitted { get; set; }
    public Guid StudentId { get; set; }
}
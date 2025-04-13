namespace StudentAssignmentAPI.Constrains.Response;

public class StudentResponseDto
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
}
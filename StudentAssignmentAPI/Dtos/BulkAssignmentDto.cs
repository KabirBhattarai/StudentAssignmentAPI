using StudentAssignmentAPI.Constrains.Request;

namespace StudentAssignmentAPI.Dtos;

public class BulkAssignmentDto
{
    public List<AssignmentRequestDto> Assignments { get; set; }
}
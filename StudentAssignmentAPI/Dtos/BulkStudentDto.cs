using StudentAssignmentAPI.Constrains.Request;

namespace StudentAssignmentAPI.Dtos;

public class BulkStudentDto
{
    public List<StudentRequestDto> Students { get; set; }
}
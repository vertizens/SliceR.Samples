namespace ContosoUniversityApi.Data;

public class Instructor
{
    public int Id { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }

    public DateOnly HireDate { get; set; }

    public ICollection<CourseAssignment> CourseAssignments { get; set; } = [];
    public OfficeAssignment OfficeAssignment { get; set; }


}
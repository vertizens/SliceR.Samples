namespace ContosoUniversityApi.Data;

public class Student
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateOnly EnrollmentDate { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = [];
}
namespace ContosoUniversityApi.Data;

public class Department
{
    public int Id { get; set; }

    public string Name { get; set; }
    public decimal Budget { get; set; }
    public DateOnly StartDate { get; set; }

    public int? InstructorId { get; set; }

    public Instructor? Administrator { get; set; }
    public ICollection<Course> Courses { get; set; }

    public byte[] RowVersion { get; set; }
}
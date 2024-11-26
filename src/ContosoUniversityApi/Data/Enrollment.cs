namespace ContosoUniversityApi.Data;

public enum Grade
{
    A = 4,
    B = 3,
    C = 2,
    D = 1,
    F = 0
}

public class Enrollment
{
    public int CourseId { get; set; }
    public int StudentId { get; set; }

    public Grade? Grade { get; set; }

    public Course Course { get; set; }
    public Student Student { get; set; }
}
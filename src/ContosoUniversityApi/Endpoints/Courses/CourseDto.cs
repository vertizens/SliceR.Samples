namespace ContosoUniversityApi.Endpoints.Courses;

public class CourseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Credits { get; set; }

    public CourseDepartment Department { get; set; }

    public class CourseDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

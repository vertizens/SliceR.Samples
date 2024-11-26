using ContosoUniversityApi.Data;
using Vertizens.SliceR.Minimal;

namespace ContosoUniversityApi.Endpoints.Students;

public class StudentDto : IDomainToEntity<Student>
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Fullname => LastName + ", " + FirstName;
    public DateOnly EnrollmentDate { get; set; }

    public IList<StudentEnrollmentDto> Enrollments { get; set; } = [];

    public class StudentEnrollmentDto
    {
        public int CourseId { get; set; }
        public Grade? Grade { get; set; }
    }
}

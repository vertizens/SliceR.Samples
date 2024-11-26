using ContosoUniversityApi.Data;
using FluentValidation;

namespace ContosoUniversityApi.Endpoints.Students;

public class InsertStudent
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateOnly EnrollmentDate { get; set; }
    public IList<InsertStudentEnrollment> Enrollments { get; set; }

    public class InsertStudentEnrollment
    {
        public int CourseId { get; set; }
        public Grade? Grade { get; set; }
    }
}

internal class InsertStudentValidator : AbstractValidator<InsertStudent>
{
    public InsertStudentValidator()
    {
        RuleFor(x => x.FirstName).MaximumLength(50).NotEmpty();
        RuleFor(x => x.LastName).MaximumLength(50).NotEmpty();
        RuleFor(x => x.EnrollmentDate).GreaterThan(DateOnly.MinValue);
    }
}
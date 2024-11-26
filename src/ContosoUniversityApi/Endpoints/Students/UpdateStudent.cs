using ContosoUniversityApi.Data;
using FluentValidation;

namespace ContosoUniversityApi.Endpoints.Students;

public class UpdateStudent
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateOnly EnrollmentDate { get; set; }
    public IList<UpdateStudentEnrollment> Enrollments { get; set; }

    public class UpdateStudentEnrollment
    {
        public int CourseId { get; set; }
        public Grade? Grade { get; set; }
    }
}

internal class UpdateStudentValidator : AbstractValidator<UpdateStudent>
{
    public UpdateStudentValidator()
    {
        RuleFor(x => x.FirstName).MaximumLength(50).NotEmpty();
        RuleFor(x => x.LastName).MaximumLength(50).NotEmpty();
        RuleFor(x => x.EnrollmentDate).GreaterThan(DateOnly.MinValue);
    }
}
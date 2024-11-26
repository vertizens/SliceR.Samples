using ContosoUniversityApi.Data;
using FluentValidation;
using Vertizens.TypeMapper;

namespace ContosoUniversityApi.Endpoints.Instructors;

public class InsertInstructor
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateOnly HireDate { get; set; }
    public string Location { get; set; }
    public IList<InsertCourseAssignment> CourseAssignments { get; set; }

    public class InsertCourseAssignment
    {
        public int CourseId { get; set; }
    }
}

internal class InsertInstructorTypeMapperBuilder(
    ) : ITypeMapperBuilder<InsertInstructor, Instructor>
{
    public void Build(ITypeMapperExpressionBuilder<InsertInstructor, Instructor> expressionBuilder)
    {
        expressionBuilder
            .ApplyNameMatch()
            .Map(x => x.OfficeAssignment, x => new OfficeAssignment { Location = x.Location });
    }
}

internal class InsertInstructorValidator : AbstractValidator<InsertInstructor>
{
    public InsertInstructorValidator()
    {
        RuleFor(x => x.FirstName).MaximumLength(50).NotEmpty();
        RuleFor(x => x.LastName).MaximumLength(50).NotEmpty();
        RuleFor(x => x.HireDate).GreaterThan(DateOnly.MinValue);
        RuleFor(x => x.Location).MaximumLength(50).NotEmpty();
    }
}

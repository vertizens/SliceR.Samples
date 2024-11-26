using ContosoUniversityApi.Data;
using FluentValidation;
using Vertizens.TypeMapper;

namespace ContosoUniversityApi.Endpoints.Instructors;

public class UpdateInstructor
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateOnly HireDate { get; set; }
    public string Location { get; set; }

    public IList<UpdateCourseAssignment> CourseAssignments { get; set; }

    public class UpdateCourseAssignment
    {
        public int CourseId { get; set; }
    }
}

internal class UpdateInstructorTypeMapperBuilder(
    ) : ITypeMapperBuilder<UpdateInstructor, Instructor>
{
    public void Build(ITypeMapperExpressionBuilder<UpdateInstructor, Instructor> expressionBuilder)
    {
        expressionBuilder
            .ApplyNameMatch()
            .Map(x => x.OfficeAssignment.Location, x => x.Location);
    }
}

public class UpdateInstructorValidator : AbstractValidator<UpdateInstructor>
{
    public UpdateInstructorValidator()
    {
        RuleFor(x => x.FirstName).MaximumLength(50).NotEmpty();
        RuleFor(x => x.LastName).MaximumLength(50).NotEmpty();
        RuleFor(x => x.HireDate).GreaterThan(DateOnly.MinValue);
        RuleFor(x => x.Location).MaximumLength(50).NotEmpty();
    }
}
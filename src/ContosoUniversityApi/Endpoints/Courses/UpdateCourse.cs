using FluentValidation;

namespace ContosoUniversityApi.Endpoints.Courses;

public class UpdateCourse
{
    public string Title { get; init; }
    public int Credits { get; init; }
    public int DepartmentId { get; init; }
}

internal class UpdateCourseValidator : AbstractValidator<UpdateCourse>
{
    public UpdateCourseValidator()
    {
        RuleFor(x => x.Title).MinimumLength(3).MaximumLength(50).NotEmpty();
        RuleFor(x => x.Credits).InclusiveBetween(0, 5);
    }
}

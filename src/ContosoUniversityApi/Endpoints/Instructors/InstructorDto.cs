using ContosoUniversityApi.Data;
using System.Linq.Expressions;
using Vertizens.TypeMapper;

namespace ContosoUniversityApi.Endpoints.Instructors;

public class InstructorDto
{
    public int Id { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }

    public DateOnly HireDate { get; set; }

    public string Fullname => LastName + ", " + FirstName;

    public string Location { get; set; }

    public IList<CourseAssignmentDto> CourseAssignments { get; set; }

    public class CourseAssignmentDto
    {
        public int CourseId { get; set; }
    }
}

internal class InstructorProjector(
    ITypeProjectorExpressionBuilder<Instructor, InstructorDto> _expressionBuilder
    ) : ITypeProjector<Instructor, InstructorDto>
{
    public Expression<Func<Instructor, InstructorDto>> GetProjection()
    {
        return _expressionBuilder
            .ApplyNameMatch()
            .Union(x => new InstructorDto { Location = x.OfficeAssignment.Location })
            .Build();
    }
}

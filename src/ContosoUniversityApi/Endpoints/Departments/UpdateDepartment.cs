using ContosoUniversityApi.Data;
using FluentValidation;
using Vertizens.TypeMapper;

namespace ContosoUniversityApi.Endpoints.Departments;

public class UpdateDepartment
{
    public string Name { get; set; }
    public decimal Budget { get; set; }
    public DateOnly StartDate { get; set; }
    public int? AdministratorId { get; set; }
}

internal class UpdateDepartmentTypeMapperBuilder : ITypeMapperBuilder<UpdateDepartment, Department>
{
    public void Build(ITypeMapperExpressionBuilder<UpdateDepartment, Department> expressionBuilder)
    {
        expressionBuilder
            .ApplyNameMatch()
            .Map(x => x.InstructorId, x => x.AdministratorId);
    }
}

internal class UpdateDepartmentValidator : AbstractValidator<UpdateDepartment>
{
    public UpdateDepartmentValidator()
    {
        RuleFor(x => x.Name).MinimumLength(3).MaximumLength(50).NotEmpty();
        RuleFor(x => x.AdministratorId).GreaterThan(0);
    }
}

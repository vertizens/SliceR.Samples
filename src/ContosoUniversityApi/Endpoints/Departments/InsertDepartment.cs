using ContosoUniversityApi.Data;
using FluentValidation;
using Vertizens.TypeMapper;

namespace ContosoUniversityApi.Endpoints.Departments;

public class InsertDepartment
{
    public string Name { get; set; }
    public decimal Budget { get; set; }
    public DateOnly StartDate { get; set; }
    public int? AdministratorId { get; set; }
}

internal class InsertDepartmentTypeMapperBuilder : ITypeMapperBuilder<InsertDepartment, Department>
{
    public void Build(ITypeMapperExpressionBuilder<InsertDepartment, Department> expressionBuilder)
    {
        expressionBuilder
            .ApplyNameMatch()
            .Map(x => x.InstructorId, x => x.AdministratorId);
    }
}

internal class InsertDepartmentValidator : AbstractValidator<InsertDepartment>
{
    public InsertDepartmentValidator()
    {
        RuleFor(x => x.Name).MinimumLength(3).MaximumLength(50).NotEmpty();
        RuleFor(x => x.AdministratorId).GreaterThan(0);
    }
}
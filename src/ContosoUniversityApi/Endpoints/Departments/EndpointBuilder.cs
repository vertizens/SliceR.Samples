using ContosoUniversityApi.Data;
using Vertizens.SliceR.Minimal;

namespace ContosoUniversityApi.Endpoints.Departments;

public class EndpointBuilder : IEndpointBuilder
{
    public IEndpointRouteBuilder Build(IEndpointRouteBuilder builder)
    {
        var entityRouteGroup = builder.MapEntityRouteGroup<Department, int, DepartmentDto>();
        entityRouteGroup.MapGetAsNoFilterQueryable();
        entityRouteGroup.MapGetAsById();
        entityRouteGroup.MapPostAsInsert<InsertDepartment>();
        entityRouteGroup.MapPutAsUpdateById<UpdateDepartment>();
        entityRouteGroup.MapDeleteAsById();

        return builder;
    }
}


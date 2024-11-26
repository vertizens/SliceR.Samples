using ContosoUniversityApi.Data;
using Vertizens.SliceR.Minimal;

namespace ContosoUniversityApi.Endpoints.Departments;

public class EndpointBuilder : IEndpointBuilder
{
    public IEndpointRouteBuilder Build(IEndpointRouteBuilder builder)
    {
        var rootRouteGroup = builder.MapRootRouteGroup<Department>();
        rootRouteGroup.MapGetAsNoFilterQueryable<DepartmentDto>();
        rootRouteGroup.MapGetAsById<int, DepartmentDto>();
        rootRouteGroup.MapPostAsInsert<InsertDepartment, DepartmentDto>();
        rootRouteGroup.MapPutAsUpdateById<int, UpdateDepartment, DepartmentDto>();
        rootRouteGroup.MapDeleteAsById<int, DepartmentDto>();

        return builder;
    }
}


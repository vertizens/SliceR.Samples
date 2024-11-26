using ContosoUniversityApi.Data;
using Vertizens.SliceR.Minimal;

namespace ContosoUniversityApi.Endpoints.Students;

public class EndpointBuilder : IEndpointBuilder
{
    public IEndpointRouteBuilder Build(IEndpointRouteBuilder builder)
    {
        var rootRouteGroup = builder.MapRootRouteGroup<Student>();
        rootRouteGroup.MapGetAsNoFilterQueryable<StudentDto>();
        rootRouteGroup.MapGetAsById<int, StudentDto>();
        rootRouteGroup.MapPostAsInsert<InsertStudent, StudentDto>();
        rootRouteGroup.MapPutAsUpdateById<int, UpdateStudent, StudentDto>();
        rootRouteGroup.MapDeleteAsById<int, StudentDto>();

        return builder;
    }
}

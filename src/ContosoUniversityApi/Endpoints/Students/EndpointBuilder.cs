using ContosoUniversityApi.Data;
using Vertizens.SliceR.Minimal;

namespace ContosoUniversityApi.Endpoints.Students;

public class EndpointBuilder : IEndpointBuilder
{
    public IEndpointRouteBuilder Build(IEndpointRouteBuilder builder)
    {
        var entityRouteGroup = builder.MapEntityRouteGroup<Student, int, StudentDto>();
        entityRouteGroup.MapGetAsNoFilterQueryable();
        entityRouteGroup.MapGetAsById();
        entityRouteGroup.MapPostAsInsert<InsertStudent>();
        entityRouteGroup.MapPutAsUpdateById<UpdateStudent>();
        entityRouteGroup.MapDeleteAsById();

        return builder;
    }
}

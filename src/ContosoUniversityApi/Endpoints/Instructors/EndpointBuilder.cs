using ContosoUniversityApi.Data;
using Vertizens.SliceR.Minimal;

namespace ContosoUniversityApi.Endpoints.Instructors;

public class EndpointBuilder : IEndpointBuilder
{
    public IEndpointRouteBuilder Build(IEndpointRouteBuilder builder)
    {
        var entityRouteGroup = builder.MapEntityRouteGroup<Instructor, int, InstructorDto>();
        entityRouteGroup.MapGetAsNoFilterQueryable();
        entityRouteGroup.MapGetAsById();
        entityRouteGroup.MapPostAsInsert<InsertInstructor>();
        entityRouteGroup.MapPutAsUpdateById<UpdateInstructor>();
        entityRouteGroup.MapDeleteAsById();

        return builder;
    }
}

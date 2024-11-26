using ContosoUniversityApi.Data;
using Vertizens.SliceR.Minimal;

namespace ContosoUniversityApi.Endpoints.Instructors;

public class EndpointBuilder : IEndpointBuilder
{
    public IEndpointRouteBuilder Build(IEndpointRouteBuilder builder)
    {
        var rootRouteGroup = builder.MapRootRouteGroup<Instructor>();
        rootRouteGroup.MapGetAsNoFilterQueryable<InstructorDto>();
        rootRouteGroup.MapGetAsById<int, InstructorDto>();
        rootRouteGroup.MapPostAsInsert<InsertInstructor, InstructorDto>();
        rootRouteGroup.MapPutAsUpdateById<int, UpdateInstructor, InstructorDto>();
        rootRouteGroup.MapDeleteAsById<int, InstructorDto>();

        return builder;
    }
}

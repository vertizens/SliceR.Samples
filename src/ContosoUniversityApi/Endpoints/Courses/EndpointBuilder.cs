using ContosoUniversityApi.Data;
using Vertizens.SliceR.Minimal;

namespace ContosoUniversityApi.Endpoints.Courses;

public class EndpointBuilder : IEndpointBuilder
{
    public IEndpointRouteBuilder Build(IEndpointRouteBuilder builder)
    {
        var entityRouteGroup = builder.MapEntityRouteGroup<Course, int, CourseDto>();
        entityRouteGroup.MapGetAsNoFilterQueryable();
        entityRouteGroup.MapGetAsById();
        entityRouteGroup.MapPostAsInsert<InsertCourse>();
        entityRouteGroup.MapPutAsUpdateById<UpdateCourse>();
        entityRouteGroup.MapDeleteAsById();

        return builder;
    }
}


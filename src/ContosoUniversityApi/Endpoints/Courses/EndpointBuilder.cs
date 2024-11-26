using ContosoUniversityApi.Data;
using Vertizens.SliceR.Minimal;

namespace ContosoUniversityApi.Endpoints.Courses;

public class EndpointBuilder : IEndpointBuilder
{
    public IEndpointRouteBuilder Build(IEndpointRouteBuilder builder)
    {
        var rootRouteGroup = builder.MapRootRouteGroup<Course>();
        rootRouteGroup.MapGetAsNoFilterQueryable<CourseDto>();
        rootRouteGroup.MapGetAsById<int, CourseDto>();
        rootRouteGroup.MapPostAsInsert<InsertCourse, CourseDto>();
        rootRouteGroup.MapPutAsUpdateById<int, UpdateCourse, CourseDto>();
        rootRouteGroup.MapDeleteAsById<int, CourseDto>();

        return builder;
    }
}


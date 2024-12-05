using ContosoUniversityApi.Data;
using Microsoft.EntityFrameworkCore;
using Vertizens.SliceR;
using Vertizens.SliceR.Minimal;
using Vertizens.SliceR.Operations.EntityFrameworkCore;
using Vertizens.SliceR.Validated.Fluent;
using Vertizens.TypeMapper;

namespace ContosoUniversityApi;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddDbContext<SchoolContext>(options =>
        {
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ContosoUniversityApi;Trusted_Connection=True;");
        });

        //Add SliceR building blocks as needed
        services.AddTypeMappers();
        services.AddSliceRHandlers();
        services.AddSliceRValidatedHandlers();
        services.AddSliceREndpointBuilders();
        services.AddSliceREntityFrameworkCoreDefaultHandlers();
        services.AddSliceREndpointDefaultValidatedHandlers();
        services.AddSliceRFluentValidators();


        return services;
    }
}

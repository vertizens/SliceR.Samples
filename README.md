# SliceR.Samples

Samples for usage of SliceR.

## Contoso University API

Sample of a mostly convention based API for CRUD with some customization for Domain models.

## Build your own API

Quick steps of creating an API

#### Use Extensions
* Vertizens.SliceR.Minimal
* Vertizens.SliceR.Operations.EntityFrameworkCore
* Vertizens.SliceR.Validated.Fluent

#### App builder (Program.cs)
* call to register services
* app.AddEndpointBuilders();
	
#### Services
Register in dependency order
```
services.AddDbContext...
services.AddTypeMappers(); //TypeMapper
services.AddSliceRHandlers(); //SliceR						
services.AddSliceRValidatedHandlers(); //SliceR
services.AddSliceREndpointBuilders(); //SliceR.Minimal
services.AddSliceREntityFrameworkCoreDefaultHandlers(); //SliceR.Operations.EntityFrameworkCore
services.AddSliceREndpointDefaultValidatedHandlers(); //SliceR.Minimal
services.AddSliceRFluentValidators() //SliceR.Validated.Fluent
```
	
#### DbContext Entities
Stick with conventions

* int Id as key
* Related entities as properties with ForeignKey property {RelatedEntityName}Id
	+ ICollection&lt;RelatedEntity&gt; or RelatedEntity as type

#### AbstractValidator&lt;TRequestIn&gt;

If using Fluent Validation and need validation
	
#### IEndpointBuilder
* MapEntityRouteGroup - entity route builder if routes map to entity operations
* Map&lt;Verb&gt;As... - map endpoints
	
#### ITypeMapperBuilder&lt;TRequestIn, TEntity&gt;
* Create an implementation if the Insert or Update domain is a different graph than TEntity
* ApplyNameMatch() should be called to match name/type by default
	
#### ITypeProjector&lt;TEntity, ResponseDto&gt;
* Create an implementation if a query domain is a different graph than TEntity
* ApplyNameMatch() should be called to match name/type by default then Union with custom

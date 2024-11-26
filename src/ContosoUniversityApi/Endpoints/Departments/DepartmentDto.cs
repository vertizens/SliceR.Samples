using ContosoUniversityApi.Data;
using Vertizens.SliceR.Minimal;

namespace ContosoUniversityApi.Endpoints.Departments;

public class DepartmentDto : IDomainToEntity<Department>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Budget { get; set; }
    public DateOnly StartDate { get; set; }
    public DepartmentAdministrator? Administrator { get; set; }

    public class DepartmentAdministrator
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Fullname => LastName + ", " + FirstName;
    }
}

using Domain.Enums;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly? BirthdayDate { get; set; }
        public Gender? Gender { get; set; }
        public DateOnly? DateOfJoining { get; set; }
        public string WorkEmail { get; set; }
        public int? OfficeId { get; set; }
        public virtual Office Office { get; set; }
        public virtual List<EmployeeStackTechnology> EmployeeStackTechnologies { get; set; }
        public virtual List<EmployeeRole> EmployeeRoles { get; set; }
        public virtual List<EmployeeProject> EmployeeProjects { get; set; }
    }
}
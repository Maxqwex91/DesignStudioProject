namespace Domain.Entities
{
    public class StackTechnology : BaseEntity
    {
        public string Name { get; set; }
        public virtual List<EmployeeStackTechnology> EmployeeStackTechnologies { get; set; }
    }
}

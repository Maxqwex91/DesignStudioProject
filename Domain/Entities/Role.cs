namespace Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public virtual List<EmployeeRole> EmployeeRoles { get; set; }
    }
}
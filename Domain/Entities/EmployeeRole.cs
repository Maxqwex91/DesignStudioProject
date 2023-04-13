namespace Domain.Entities
{
    public class EmployeeRole
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}

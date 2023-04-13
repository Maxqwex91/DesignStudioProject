namespace Domain.Entities
{
    public class EmployeeStackTechnology
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int StackTechnologyId { get; set; }
        public virtual StackTechnology StackTechnology { get; set; }
    }
}

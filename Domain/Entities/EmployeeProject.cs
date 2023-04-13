namespace Domain.Entities
{
    public class EmployeeProject
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual List<TimeLog> TimeLogs { get; set; }
    }
}

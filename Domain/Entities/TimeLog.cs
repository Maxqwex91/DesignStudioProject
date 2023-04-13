namespace Domain.Entities
{
    public class TimeLog : BaseEntity
    {
        public string Comment { get; set; }
        public double Duration { get; set; }
        public DateOnly Date { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public virtual EmployeeProject EmployeeProject { get; set; }
    }
}

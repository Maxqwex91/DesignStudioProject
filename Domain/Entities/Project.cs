namespace Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<ProjectTask> ProjectTasks { get; set; }
        public virtual List<EmployeeProject> EmployeeProjects { get; set; }
    }
}
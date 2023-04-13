namespace Domain.Entities
{
    public class ProjectTask : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}

namespace Domain.Entities
{
    public class Office : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}

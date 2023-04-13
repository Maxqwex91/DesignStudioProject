namespace Domain.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneCode { get; set; }
        public virtual List<Office> Offices { get; set; }
    }
}

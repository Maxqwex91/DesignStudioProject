namespace Domain.Entities
{
    public class SocialNetwork : BaseEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}

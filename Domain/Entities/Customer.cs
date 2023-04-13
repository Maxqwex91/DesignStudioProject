namespace Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<SocialNetwork> SocialNetworks { get; set; }
        public virtual List<Project> Projects { get; set; }
    }
}

namespace Models.DTOs.Output
{
    public class CustomerSocialNetworksDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<SocialNetworkDTO> SocialNetworks { get; set; }
    }
}

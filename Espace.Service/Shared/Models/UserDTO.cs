namespace Espace.Service.Shared.Models
{
    public class UserDTO
    {
        public string Nickname { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Created  { get; set; }
        public string Type { get; set; }
    }
}
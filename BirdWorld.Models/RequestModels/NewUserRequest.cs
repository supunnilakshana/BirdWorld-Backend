namespace BirdWorld.Models.RequestModels
{
    public class NewUserRequest
    {

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}

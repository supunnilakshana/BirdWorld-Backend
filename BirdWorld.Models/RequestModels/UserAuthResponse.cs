namespace BirdWorld.Models.RequestModels
{
    public class UserAuthResponse
    {
        public string   token { get; set; }
        public AppUserDto  user { get; set; }
    }
}

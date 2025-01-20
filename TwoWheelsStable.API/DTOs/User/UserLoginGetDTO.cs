namespace api.DTOs.User
{
    public class UserLoginGetDTO
    {
        public string Href { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}

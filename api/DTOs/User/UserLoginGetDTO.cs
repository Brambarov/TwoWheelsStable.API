namespace api.DTOs.User
{
    public class UserLoginGetDTO
    {
        public string Id { get; set; } = string.Empty;
        /*public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;*/
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}

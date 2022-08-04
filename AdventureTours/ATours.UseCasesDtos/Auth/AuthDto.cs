namespace ATours.UseCasesDtos.Auth
{
    public class AuthDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public bool Ok { get; } = true;
    }
}

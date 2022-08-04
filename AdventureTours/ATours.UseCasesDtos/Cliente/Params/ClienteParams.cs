namespace ATours.UseCasesDtos.Users.Params
{
    public class ClienteParams
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string CellPhone { get; set; }

        public bool IsActive { get; set; }

        public string Password { get; set; }
    }
}

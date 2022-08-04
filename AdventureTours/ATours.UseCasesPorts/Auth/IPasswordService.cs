namespace ATours.UseCasesPorts.Auth
{
    public  interface IPasswordService
    {
        string Hash(string password);
        bool Check(string hash, string password);
        string GenerateRandomPassword(int length);
    }
}

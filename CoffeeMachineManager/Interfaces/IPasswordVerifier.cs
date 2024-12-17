namespace CoffeeMachineManager.Interfaces
{
    public interface IPasswordVerifier
    {
        bool VerifyHash(string userPwdInput, string hash);
    }
}

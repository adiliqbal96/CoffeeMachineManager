using System.Collections;

namespace CoffeeMachineManager.Interfaces
{
    public interface IPasswordHasher
    {
        string GetHash(string password);
    }
}

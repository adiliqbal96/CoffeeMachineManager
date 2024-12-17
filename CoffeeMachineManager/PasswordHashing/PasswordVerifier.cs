using CoffeeMachineManager.Interfaces;

namespace CoffeeMachineManager.PasswordHashing
{
    public class PasswordVerifier : IPasswordVerifier
    {
        public IPasswordHasher Hasher { get; set; }

        public PasswordVerifier(IPasswordHasher hasher)
        {
            Hasher = hasher;
        }

        public bool VerifyHash(string userPwdInput, string hash)
        {
            // Hash the input.
            string hashOfInput = Hasher.GetHash(userPwdInput);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
}

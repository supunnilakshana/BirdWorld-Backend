namespace BirdWorld.Helpers
{
    public class RadomStringGenerator
    {

        private const string ValidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private readonly Random random = new Random();
        public RadomStringGenerator() { }

        public string GenerateRandomString(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length must be greater than 0.", nameof(length));
            }

            char[] randomChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                randomChars[i] = ValidChars[random.Next(ValidChars.Length)];
            }

            return new string(randomChars);
        }
    }
}

namespace TaskB3.Domain.Providers.Hash
{
    public sealed class HashingOptions
    {
        public const string Hashing = "Hashing";

        public int Iterations { get; set; } = 10000;
    }
}

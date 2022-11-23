namespace MiniBankingApp.Utilities
{
    public static class IdGenerator
    {
        public static string GenerateId()
        {
            return Guid.NewGuid().ToString()[..20];
        }
    }
}

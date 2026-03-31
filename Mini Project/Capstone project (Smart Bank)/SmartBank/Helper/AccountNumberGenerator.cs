namespace AccountsAPI.Helper
{
    public class AccountNumberGenerator
    {
        public static string Generate(int id)
        {
            string unique = new string('0', 6 - id.ToString().Length);
            unique += id.ToString();
            return $"SB-{DateTime.Today.Year}-{unique}";
        }
    }
}

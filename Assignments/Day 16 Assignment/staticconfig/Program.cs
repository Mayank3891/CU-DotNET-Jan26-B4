namespace staticconfig
{
    internal class Program
    {
        internal class ApplicationConfig
        {
            static public string ApplicationName { get; set; }
            static public string Environment {  get; set; }
            static public int AccessCount {  get; set; }
            static public bool IsInitialized {  get; set; }

            static ApplicationConfig() {
                ApplicationName = "MyApp";
                Environment = "Development";
                AccessCount = 0;
                IsInitialized = false;
                Console.WriteLine("static constructor executed");

            }
            static public void Initialize(string AppName, string enviornment)
            {
                ApplicationName = AppName;
                Environment = enviornment;
                IsInitialized=true;
                AccessCount++;

            }
            static public string GetConfigurationSummary()
            {
                AccessCount++;
                return $"{ApplicationName}  {Environment}   {AccessCount}   {IsInitialized}";
            }
            static public void ResetConfiguration()
            {
                ApplicationName = "MyApp";
                Environment = "Development";
                IsInitialized = false;
                AccessCount++;
            }
        }
        static void Main(string[] args)
        {
            ApplicationConfig.Initialize("Another app","WEBSITE");
            Console.WriteLine(ApplicationConfig.GetConfigurationSummary());
            ApplicationConfig.ResetConfiguration();
            Console.WriteLine(ApplicationConfig.GetConfigurationSummary());
        }
    }
}

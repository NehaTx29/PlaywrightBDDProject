using DotNetEnv;

public static class Config
{
    static Config()
    {
        var EnvPath = Path.Combine(GetProjectPath(), ".env");
        Env.Load(EnvPath);
    }

    public static string GetProjectPath()
    {
        string currentDir = Directory.GetCurrentDirectory();
        string projectDir = Path.GetFullPath(Path.Combine(currentDir, @"..\..\..\"));
        return projectDir;
    }

    public static string GoogleUrl => Env.GetString("GOOGLE_URL");
    public static string AmazonUrl => Env.GetString("AMAZON_URL");
    public static string TestOutputFolder =>
        Path.Combine(GetProjectPath(), Env.GetString("TEST_OUTPUT_FOLDER"));
    public static string ScreenshotFolder =>
        Path.Combine(GetProjectPath(), Env.GetString("SCREENSHOT_FOLDER"));
    public static string BrowserName => Env.GetString("BROWSER_NAME");
    public static bool Headless => bool.Parse(Env.GetString("HEADLESS"));
    public static int Timeout => int.Parse(Env.GetString("TIMEOUT"));
}

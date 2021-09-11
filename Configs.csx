#r "nuget: Microsoft.Extensions.Configuration, 5.0.0"
#r "nuget: Microsoft.Extensions.Configuration.Binder, 5.0.0"
#r "nuget: Microsoft.Extensions.Configuration.UserSecrets, 5.0.0"
#r "nuget: Microsoft.Extensions.Configuration.EnvironmentVariables, 5.0.0"

using Microsoft.Extensions.Configuration;

public static class Configs
{
    private static IConfiguration _config;

    public static IConfiguration Configuration 
    {
        get 
        {
            if (_config is null)
                SetConfig();
            
            return _config;
        }
    }

    private static void SetConfig()
    {
        _config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddUserSecrets("csx-script-app")
                        .AddEnvironmentVariables()
                        .Build();
    }

    public static T GetConfig<T>(string sectionName)
    {
        return Configuration.GetSection(sectionName).Get<T>();
    }
}

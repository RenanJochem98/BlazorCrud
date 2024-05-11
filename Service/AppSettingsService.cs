using Microsoft.Extensions.Configuration;

namespace BlazorLogin.Service
{
    public class AppSettingsService
    {
        private static IConfiguration configuration;
        static AppSettingsService()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
        }

        //TODO: Usar cache para salvar a string sem precisar ler o arquivo sempre
        public static string GetConnectionString()
        {
            return configuration.GetSection("ConnectionStrings").GetSection("postgres").Value!;
        }
    }
}

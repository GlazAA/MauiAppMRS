using MauiAppMRS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
// добавили в этапе 2, пункт 2-3
using MauiAppMRS.Core.Interfaces;
// тоже
using MauiAppMRS.Infrastructure.Repositories;


namespace MauiAppMRS
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.SetMinimumLevel(LogLevel.Debug);
            builder.Logging.AddDebug();
#endif

            // Регистрация DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=checklist.db"));

            // Регистрируем репозитории в DI, это глобально этап 2, локально 2-3. 
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            return builder.Build();
        }
    }
}

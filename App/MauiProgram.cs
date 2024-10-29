using Microsoft.Extensions.Logging;
using App.DataAccess;

namespace App
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddDbContext<AppDbContext>();
            builder.Services.AddTransient<SignPage>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            // Inicializa la base de datos
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                /*dbContext.Database.EnsureDeleted();*/  // Elimina la base de datos si existe
                dbContext.Database.EnsureCreated();  // Crea la base de datos
            }

            return app;
        }
    }
}

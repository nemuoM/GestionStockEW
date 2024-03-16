using Microsoft.Extensions.Logging;

namespace GestionStockEW
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
                    fonts.AddFont("Conso-Bold.ttf", "ConsoBold");
                    fonts.AddFont("Conso-Regular.ttf", "ConsoRegular");
                    fonts.AddFont("Conso-Thin.ttf", "ConsoThin");
                    fonts.AddFont("GSKPrecision-Regular.ttf", "GSKPrecision");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
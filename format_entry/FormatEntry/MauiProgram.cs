using Microsoft.Extensions.Logging;

namespace FormatEntry;

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

#if IOS
        builder.ConfigureMauiHandlers(handlers =>
        {
            // Yalnızca NumericEntry için CustomEntryHandler ekle
            handlers.AddHandler<NumericEntry, CustomEntryHandler>();
        });
#endif

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

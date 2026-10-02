using Microsoft.Extensions.Logging;
using UmarSons.Mobile.Services;

namespace UmarSons.Mobile
{
    public static class MauiProgram
    {
        // ⚠️ Change this to match the API URL the mobile app should call.
        // If the API is running on your dev machine and you're testing on an emulator,
        // use your PC's LAN IP (e.g. http://192.168.1.50:5000/), not localhost.
        private const string ApiBaseUrl = "https://localhost:7129/";

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

            builder.Services.AddSingleton<HttpClient>(sp =>
            {
                var handler = new HttpClientHandler
                {
                    UseCookies = true,
                    CookieContainer = new System.Net.CookieContainer(),
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                };

                var client = new HttpClient(handler)
                {
                    BaseAddress = new Uri(ApiBaseUrl),
                    Timeout = TimeSpan.FromSeconds(30)
                };

                return client;
            });
            builder.Services.AddSingleton<ApiService>();
            // =====================================

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
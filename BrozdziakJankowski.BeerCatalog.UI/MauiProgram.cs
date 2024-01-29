using BrozdziakJankowski.BeerCatalog.BL;
using BrozdziakJankowski.BeerCatalog.DAO;
using BrozdziakJankowski.BeerCatalog.Interfaces;
using Microsoft.Extensions.Logging;

namespace BrozdziakJankowski.BeerCatalog.UI
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
            builder.Services.AddDbContext<BeerCatalogContext>();

            builder.Services.AddScoped<IBeerService, BeerService>();
            builder.Services.AddScoped<IBeerRepository, BeerRepository>();
            builder.Services.AddScoped<IProducerService, ProducerService>();
            builder.Services.AddScoped<IProducerRepository, ProducerRepository>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<AddProducerPage>();
            builder.Services.AddSingleton<ProducerListPage>();
            builder.Services.AddSingleton<AddBeerPage>();
            builder.Services.AddSingleton<BeerListPage>();
            Routing.RegisterRoute(nameof(AddProducerPage), typeof(AddProducerPage));
            Routing.RegisterRoute(nameof(ProducerListPage), typeof(ProducerListPage));
            Routing.RegisterRoute(nameof(AddBeerPage), typeof(AddBeerPage));
            Routing.RegisterRoute(nameof(BeerListPage), typeof(BeerListPage));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

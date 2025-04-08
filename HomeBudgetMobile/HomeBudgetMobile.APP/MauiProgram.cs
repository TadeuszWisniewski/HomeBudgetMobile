//using HomeBudgetMobile.APP.Services;
using HomeBudgetMobile.APP.ViewModels;
using HomeBudgetMobile.APP.Views;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

using HomeBudgetMobile.APP.Services;

namespace HomeBudgetMobile.APP
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

            builder.Services.AddTransient<HbmApiService>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<ExpenseSortsPage>();
            builder.Services.AddTransient<ExpensesPage>();
            builder.Services.AddTransient<GoalsPage>();
            builder.Services.AddTransient<IncomesPage>();
            builder.Services.AddTransient<IncomeSourcePage>();
            builder.Services.AddTransient<LogInPage>();
            builder.Services.AddTransient<SavingsPage>();
            builder.Services.AddTransient<SummaryPage>();

            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<ExpenseSortsViewModel>();
            builder.Services.AddTransient<ExpensesViewModel>();
            builder.Services.AddTransient<GoalsViewModel>();
            builder.Services.AddTransient<IncomesViewModel>();
            builder.Services.AddTransient<IncomeSourceViewModel>();
            builder.Services.AddTransient<LogInPageViewModel>();
            builder.Services.AddTransient<SavingsViewModel>();
            builder.Services.AddTransient<SummaryViewModel>();


            //builder.Services.AddHomeBudgetClientService(x => x.ApiBaseAddress = "http://localhost:5063/");
            //builder.Services.AddTransient<MainPage>();

            ////builder.Services.AddSingleton<HomeBudgetMobileService>();

            //builder.Services.AddSingleton<SummaryViewModel>();
            //builder.Services.AddTransient<MainPageViewModel>();
            //builder.Services.AddTransient<LogInPageViewModel>();

            //builder.Services.AddSingleton<SummaryPage>();
            ////builder.Services.AddTransient<MainPage>();
            //builder.Services.AddTransient<LogInPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

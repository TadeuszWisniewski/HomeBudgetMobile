using HomeBudgetMobile.APP.Views;

namespace HomeBudgetMobile.APP
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LogInPage), typeof(LogInPage));
            Routing.RegisterRoute(nameof(SummaryPage), typeof(SummaryPage));
            Routing.RegisterRoute(nameof(IncomesPage), typeof(IncomesPage));
            Routing.RegisterRoute(nameof(IncomeSourcePage), typeof(IncomeSourcePage));
            Routing.RegisterRoute(nameof(SavingsPage), typeof(SavingsPage));
            Routing.RegisterRoute(nameof(ExpensesPage), typeof(ExpensesPage));
            Routing.RegisterRoute(nameof(ExpenseSortsPage), typeof(ExpenseSortsPage));
            Routing.RegisterRoute(nameof(GoalsPage), typeof(GoalsPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }
    }
}

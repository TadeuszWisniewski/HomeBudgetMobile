
namespace HomeBudgetMobile.APP
{
    public partial class App : Application
    {
        //public App(MainPage mainPage)
        public App()
        {
            InitializeComponent();

            //MainPage = mainPage;

            MainPage = new AppShell();
            //var navigationPage = new NavigationPage(new MainPage());
            ////navigationPage.BarBackgroundColor = Colors.Green;
            //MainPage = navigationPage;

        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            const int newWidth = 600;
            const int newHeight = 800;

            window.MaximumWidth = newWidth;
            window.MaximumHeight = newHeight;
            window.MinimumHeight = newHeight;
            window.MinimumWidth = newWidth;

            return window;
        }
    }
}

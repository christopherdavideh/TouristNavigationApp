namespace TouristNavigationApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.DashboardPage();
            //MainPage = new Views.NavigationPage();
        }
    }
}

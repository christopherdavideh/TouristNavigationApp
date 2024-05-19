using TouristNavigationApp.Views;

namespace TouristNavigationApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ProfilePage();
        }
    }
}

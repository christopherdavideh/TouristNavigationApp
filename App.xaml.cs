using TouristNavigationApp.Views;

namespace TouristNavigationApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MapsPage())
            {
                
                BarBackgroundColor = Colors.White,
                BarTextColor = Colors.Black
            };
        
        }
    }
}

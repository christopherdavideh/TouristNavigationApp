using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.ObjectModel;
using TouristNavigationApp.Models;

namespace TouristNavigationApp.Views;

public partial class MapsPage : ContentPage
{
    private const string URL = "http://192.168.100.158:8080/api/v1/places";
    private readonly HttpClient _httpClient = new HttpClient();
    public ObservableCollection<Position> _positions { get; set; }

    public IEnumerable Positions => _positions;
    public MapsPage()
	{
		InitializeComponent();
        map.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(-0.44789479126361315, -78.64897443223752), Distance.FromMiles(100)));

        //_positions = new ObservableCollection<Position>()
        //{
        //    new Position("New York, USA", "The City That Never Sleeps", new Location(40.67, -73.94)),
        //    new Position("Los Angeles, USA", "City of Angels", new Location(34.11, -118.41)),
        //    new Position("San Francisco, USA", "Bay City", new Location(37.77, -122.45))
        //};
        getPlaces();
    }

    public async void getPlaces()
    {
        var content = await _httpClient.GetStringAsync(URL);
        List<Places> places = JsonConvert.DeserializeObject<List<Places>>(content);
        _positions = new ObservableCollection<Position>();
        foreach (Places place in places)
        {
            _positions.Add(new Position(
                place.plaDetail,
                place.plaName,
                new Location(place.plaLatitude, place.plaLongitude)
            ));
        }
        
        map.ItemsSource = _positions;
    }
}
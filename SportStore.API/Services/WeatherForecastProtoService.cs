namespace SportStore.API.Services;

public class WeatherForecastProtoService: protoWeatherForecasts.protoWeatherForecastsBase
{
    private static readonly string[] Summaries = new[]
     {
     "Freezing", "Cool", "Warm", "Hot", "Sweltering", "Scorching"
     };
}

//using Bunit;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
//using Moq;
//using SportStore.Blazor.Components;
//using System.Diagnostics.Metrics;

//namespace SportStore.Tests;

//public class CounterShould : TestContext
//{
//    [Fact]
//    public void RenderCorrectlyWithInitialZero()
//    {
//        var cut = RenderComponent<Home>();
//        cut.MarkupMatches(@"<h1>Hello World</h1>");

//    }

//    [Fact]
//    public void RenderParagraphCorrectlyWithInitialZero()
//    {
//        var cut = RenderComponent<Home>();
//        cut.Find(cssSelector: "h1")
//        .MarkupMatches("<h1>Hello World</h1>");
//    }


//    [Fact]
//    public void IncrementCounterWhenButtonIsClicked()
//    {
//        var cut = RenderComponent<Home>();
//        cut.Find(cssSelector: "button")
//        .Click();
//        cut.Find(cssSelector: "p")
//        .MarkupMatches(@"<p>Current count: 1</p>");
//    }

//    [Theory]
//    [InlineData(3)]
//    [InlineData(-3)]
//    public void IncrementCounterWithIncrementWhenClickedWithNameOf(int increment)
//    {
//        //var cut = RenderComponent<TwoWayCounter>(
//        //(nameof(TwoWayCounter.CurrentCount), 0),
//        //(nameof(TwoWayCounter.Increment), increment)
//        //);

//        //cut.Find("button").Click();
//        //cut.Find("p")
//        //.MarkupMatches($"<p>Current count: {increment}</p>");
//    }

//    /// <summary>
//    /// Implement Stub with Moq
//    /// </summary>

//    [Fact]
//    public void UseWeatherServiceMOQ()
//    {
//        //const int nrOfForecasts = 5;
//        //var forecasts = Enumerable.Repeat(new WeatherForecast(), nrOfForecasts);
//        //Mock<IWeatherService> stub = new Mock<IWeatherService>();
//        //stub.Setup(s => s.GetForecasts())
//        //.Returns(new ValueTask<IEnumerable<WeatherForecast>>(forecasts));
//        //Services.AddSingleton<IWeatherService>(stub.Object);
//        //Mock<ILogger> loggerStub = new Mock<ILogger>();
//        //Services.AddSingleton<ILogger>(loggerStub.Object);
//        //var cut = RenderComponent<FetchData>();
//        //var rows = cut.FindAll("tbody tr");
//        //rows.Count.Should().Be(nrOfForecasts);
//    }


//    /// <summary>
//    /// Implement Mock with Moq
//    /// </summary>

//    [Fact]
//    public void UseProperLoggingMOQ()
//    {
//        //const int nrOfForecasts = 5;
//        //var forecasts = Enumerable.Repeat(new WeatherForecast(), nrOfForecasts);
//        //Mock<IWeatherService> stub = new Mock<IWeatherService>();
//        //stub.Setup(s => s.GetForecasts())
//        //.Returns(new ValueTask<IEnumerable<WeatherForecast>>(forecasts));
//        //Services.AddSingleton<IWeatherService>(stub.Object);
//        //Mock<ILogger> loggerMock = new Mock<ILogger>();
//        //Services.AddSingleton<ILogger>(loggerMock.Object);
//        //var cut = RenderComponent<FetchData>();
//        //loggerMock.Verify(
//        //l => l.Log(
//        //It.Is<LogLevel>(l => l == LogLevel.Information),
//        //It.IsAny<EventId>(),
//        //It.Is<It.IsAnyType>(
//        //(msg, t) => msg.ToString()!
//        //.Contains("Fetching forecasts")),
//        //It.IsAny<Exception>(),
//        //It.Is<Func<It.IsAnyType, Exception?, string>>(
//        //(v, t) => true))
//        //, Times.Once);
//    }

//}
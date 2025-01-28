using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TDDTest1.Task.Task_3;

[TestClass]
public class WeatherServiceFacadeTests
{
    private WeatherClient _mockWeatherClient;
    private WeatherServiceFacade _weatherService;

    [TestInitialize]
    public void Setup()
    {
        _mockWeatherClient = Substitute.For<WeatherClient>(new HttpClient());
        _weatherService = new WeatherServiceFacade(_mockWeatherClient);
    }

    [TestMethod]
    public async Task GetWeather_ThrowsArgumentException_ForEmptyCity()
    {
        // Arrange
        string city = "";

        // Mocka att WeatherClient kastar ArgumentException vid tom sträng
        _mockWeatherClient
            .GetCurrentWeatherAsync(Arg.Is<string>(s => string.IsNullOrWhiteSpace(s)))
            .Throws(new ArgumentException("City name cannot be null or empty."));

        // Act & Assert
        await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
        {
            await _weatherService.GetWeather(city);
        });
    }

    [TestMethod]
    public async Task GetWeather_ThrowsArgumentException_ForNullCity()
    {
        // Arrange
        string city = null;

        // Mocka att WeatherClient kastar ArgumentException vid null
        _mockWeatherClient
            .GetCurrentWeatherAsync(Arg.Is<string>(s => string.IsNullOrWhiteSpace(s)))
            .Throws(new ArgumentException("City name cannot be null or empty."));

        // Act & Assert
        await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
        {
            await _weatherService.GetWeather(city);
        });
    }

    [TestMethod]
public async Task GetWeather_ReturnsMockedWeatherData_ForGothenburg()
{
    // Arrange
    string city = "Göteborg";
    string expectedWeather = "Rainy 12°C";

    // Mocka att WeatherClient returnerar vädret för Göteborg
    _mockWeatherClient
        .GetCurrentWeatherAsync(city)
        .Returns(Task.FromResult(expectedWeather));

    // Act
    string actualWeather = await _weatherService.GetWeather(city);

    // Assert
    Assert.AreEqual(expectedWeather, actualWeather);
}
}

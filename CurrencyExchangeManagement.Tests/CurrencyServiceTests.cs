using Xunit;

using System.Net.Http.Json;
using Moq;
using CurrencyExchangeManagement.Infrastucure.Services;

public class CurrencyServiceTests
{
    private readonly Mock<HttpClient> _mockHttpClient;
    private readonly CurrencyService _currencyService;

    public CurrencyServiceTests()
    {
        _mockHttpClient = new Mock<HttpClient>();
        _currencyService = new CurrencyService(_mockHttpClient.Object);
    }

    [Fact]
    public async Task GetExchangeRate_ShouldReturnCorrectRate()
    {
        var expectedRate = 18.5M;
        var response = new HttpResponseMessage
        {
            Content = JsonContent.Create(new { Rates = new Dictionary<string, decimal> { { "ZAR", expectedRate } } })
        };
        _mockHttpClient.Setup(c => c.GetAsync(It.IsAny<string>())).ReturnsAsync(response);

        var result = await _currencyService.GetExchangeRates("USD", "ZAR");

        Assert.Equal(expectedRate, result);
    }
}

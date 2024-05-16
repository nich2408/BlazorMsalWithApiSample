using BlazorMsalWithApiSample.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http.Json;

namespace BlazorMsalWithApiSample.Client.Services
{
    public class APIClient : IDisposable
    {
        private readonly HttpClient httpClient;

        public static readonly string BaseAddress = "https://localhost:7089";

        public APIClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<WeatherForecast[]> GetForecastAsync()
        {
            WeatherForecast[]? forecasts = default;

            try
            {
                forecasts = await httpClient.GetFromJsonAsync<WeatherForecast[]>(
                    "WeatherForecast");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }

            return forecasts ?? Array.Empty<WeatherForecast>();
        }

        public void Dispose()
        {
            httpClient?.Dispose();
        }
    }
}

using Applications.DTOs.Books;
using Applications.Services;
using System.Net.Http.Json;

namespace Infrastructures.Services
{
    public class ExternalBookService : IExternalBookService
    {
        private readonly HttpClient _httpClient;

        public ExternalBookService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ExternalBookAPI");
            this.BaseUrl = $"{this._httpClient.BaseAddress}odi/verse/2/2";
        }

        public string BaseUrl { get; private set; }

        public async Task<BookExternalDto?> GetExternalBookAsync()
        {
            string dataUrl = "odi/verse/2/2";
            var response = await this._httpClient.GetAsync(dataUrl);

            response.EnsureSuccessStatusCode();

            var bookDetail = await response.Content.ReadFromJsonAsync<BookExternalDto>();

            return bookDetail;
        }
    }
}

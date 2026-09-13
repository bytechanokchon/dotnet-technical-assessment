using Applications.DTOs.Books;
using MediatR;
using System.Net.Http.Json;

namespace Applications.Handlers.Books.Queries
{
    public class GetBookDetailQuery : IRequest<BookDto>
    {
        public class GetBookDetailQueryHandler : IRequestHandler<GetBookDetailQuery, BookDto>
        {
            private readonly HttpClient _httpClient;

            public GetBookDetailQueryHandler(IHttpClientFactory httpClientFactory)
            {
                _httpClient = httpClientFactory.CreateClient("ExternalBookAPI");
            }

            public async Task<BookDto> Handle(GetBookDetailQuery request, CancellationToken cancellationToken)
            {
                string dataUrl = "/odi/verse/2/2";
                var response = await this._httpClient.GetAsync(dataUrl);

                response.EnsureSuccessStatusCode();

                var bookDetail = await response.Content.ReadFromJsonAsync<BookExternalDto>();

                return new BookDto()
                {
                    Url = $"{this._httpClient.BaseAddress}{dataUrl}",
                    Method = "GET",
                    Response = bookDetail
                };
            }
        }
    }
}

using Applications.DTOs.Books;

namespace Applications.Services
{
    public interface IExternalBookService
    {
        public string BaseUrl { get; }
        
        Task<BookExternalDto> GetExternalBookAsync();
    }
}

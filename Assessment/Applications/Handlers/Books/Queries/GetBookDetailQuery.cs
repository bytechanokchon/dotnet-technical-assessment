using Applications.DTOs.Books;
using MediatR;
using System.Net.Http.Json;

namespace Applications.Handlers.Books.Queries
{
    public class GetBookDetailQuery : IRequest<BookDto>
    {
        public class GetBookDetailQueryHandler : IRequestHandler<GetBookDetailQuery, BookDto>
        {
            private readonly IServiceUnitOfWork _serviceUnitOfWork;

            public GetBookDetailQueryHandler(IServiceUnitOfWork serviceUnitOfWork)
            {
                this._serviceUnitOfWork = serviceUnitOfWork;
            }

            public async Task<BookDto> Handle(GetBookDetailQuery request, CancellationToken cancellationToken)
            {
                var bookDetail = await this._serviceUnitOfWork.ExternalBookService.GetExternalBookAsync();

                return new BookDto()
                {
                    Url = this._serviceUnitOfWork.ExternalBookService.BaseUrl,
                    Method = "GET",
                    Response = bookDetail
                };
            }
        }
    }
}

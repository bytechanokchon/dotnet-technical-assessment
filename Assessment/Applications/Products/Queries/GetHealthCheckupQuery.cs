using Applications.DTOs;
using MediatR;

namespace Applications.Products.Queries
{
    public class GetHealthCheckupQuery : IRequest<HealthCheckupDto>
    {
        public class GetHealthCheckupQueryHandler : IRequestHandler<GetHealthCheckupQuery, HealthCheckupDto>
        {
            public async Task<HealthCheckupDto> Handle(GetHealthCheckupQuery request, CancellationToken cancellationToken)
            {
                return new HealthCheckupDto()
                {
                    IsAvalible = true,
                    Message = "Service Avalible"
                };
            }
        }
    }
}

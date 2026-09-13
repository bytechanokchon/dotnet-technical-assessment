using Applications.DTOs.Auths;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applications.Handlers.Auths.Commands
{
    public class LoginQuery : IRequest<LoginDto>
    {
        public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginDto>
        {
            private readonly IServiceUnitOfWork _serviceUnitOfWork;

            public LoginQueryHandler(IServiceUnitOfWork serviceUnitOfWork)
            {
                this._serviceUnitOfWork = serviceUnitOfWork;
            }

            public async Task<LoginDto> Handle(LoginQuery request, CancellationToken cancellationToken)
            {
                string dummyUserId = "481e6b90-ac39-42ca-ac73-c205fa54417b";
                string dummyRole = "ROLE_ADMIN";

                string token = this._serviceUnitOfWork.JwtGenerator.Generate(dummyUserId, dummyRole);

                return new LoginDto()
                {
                    Token = token
                };
            }
        }
    }
}

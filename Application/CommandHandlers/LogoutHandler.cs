using Application.Commands;
using Application.Utils;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers
{
    public class LogoutHandler : IRequestHandler<LogoutCommand>
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public LogoutHandler(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await _authenticationRepository.Logout();
            return Unit.Value;
        }
    }
}

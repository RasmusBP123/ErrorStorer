using Application.Commands;
using Application.Utils;
using AutoMapper;
using Domain;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers
{
    class LoginHandler : IRequestHandler<LoginCommand, CommandResult>
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IMapper _mapper;

        public LoginHandler(IAuthenticationRepository authenticationRepository, IMapper mapper)
        {
            _authenticationRepository = authenticationRepository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationRepository.Login(request.Email, request.Password);
            var commandResult = new CommandResult() { Successed = result.Succeeded };
            return commandResult;
        }
    }
}

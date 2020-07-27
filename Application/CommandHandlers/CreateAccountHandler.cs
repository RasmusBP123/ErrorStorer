using Application.Commands;
using Application.Utils;
using Domain;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandHandlers
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, CommandResult>
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IUnitOfWork _uow;

        public CreateAccountHandler(IAuthenticationRepository authenticationRepository, IUnitOfWork uow)
        {
            _authenticationRepository = authenticationRepository;
            _uow = uow;
        }

        public async Task<CommandResult> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            CommandResult commandResult = new CommandResult();
            commandResult.Errors = new List<string>();

            if (request.ConfirmPassword != request.Password)
            {
                commandResult  = new CommandResult{ Successed = false, Errors = new List<string>() { "Password must match" } };
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email
            };

            var result = await _authenticationRepository.CreateAccount(user, request.Password);
            await _uow.Save();

            if (result.Succeeded == false)
            {
                commandResult.Errors.AddRange(result.Errors.Select(x => x.Description));
            }

            return commandResult;
        }
    }
}

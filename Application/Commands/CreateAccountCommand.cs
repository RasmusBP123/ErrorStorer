using Application.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class CreateAccountCommand : IRequest<CommandResult>
    {
        public CreateAccountCommand(string email, string password, string confirmPassword)
        {
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public string Email { get; }
        public string Password { get; }
        public string ConfirmPassword { get; }
    }
}

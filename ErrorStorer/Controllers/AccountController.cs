using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ErrorStorer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }


        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> CreateAccount(CreateApplicationUserViewModel applicationUser)
        {
            if (applicationUser is null)
            {
                throw new ArgumentNullException(nameof(applicationUser));
            }

            var result = await _mediator.Send(new CreateAccountCommand(applicationUser.Email, applicationUser.Password, applicationUser.ConfirmPassword));
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> LoginUser(LoginViewModel loginViewModel)
        {
            var result = await _mediator.Send(new LoginCommand(loginViewModel.Email, loginViewModel.Password));
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _mediator.Send(new LogoutCommand());
            return RedirectToAction("Index", "Home");
        }
    }
}

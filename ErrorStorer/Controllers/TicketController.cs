using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Queries;
using Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ErrorStorer.Controllers
{
    public class TicketController : Controller
    {
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var tickets = await _mediator.Send(new GetAllTicketQuery());
            return View(tickets);
        }

        public async Task<IActionResult> CreateTicket(TicketViewModel ticket)
        {
            var command = new CreateTicketCommand(ticket.Title, ticket.Description, ticket.TicketNumber, ticket.Type, ticket.Status, null);

            //Should be logic in the domain
            if (ticket.Files != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await ticket.Files.CopyToAsync(memoryStream);
                    command.FileBytes = memoryStream.ToArray();
                }
            }

            await _mediator.Send(command);
            return Ok();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult DetailTicket()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DetailTicket(Guid ticketId)
        {
            var result = await _mediator.Send(new GetSingleTicketQuery(ticketId));
            return View(result);
        }
    }
}

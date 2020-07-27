using Application.Commands;
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
    public class CreateTicketHandler : IRequestHandler<CreateTicketCommand, bool>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTicketHandler(ITicketRepository ticketRepository, IUnitOfWork unitOfWork)
        {
            _ticketRepository = ticketRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var files = new List<File>() {new File(){ FileType = "doc", Stream = request.FileBytes, TimeStamp = DateTime.Now } };
            var ticket = new Ticket(request.Title, request.TicketNumber, null, request.Description, request.Type, request.Status, files);
            await _ticketRepository.CreateTicket(ticket);
            var result = await _unitOfWork.Save();

            return result;
        }
    }
}

using Application.Queries;
using Application.ViewModels;
using AutoMapper;
using Domain;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QueryHandlers
{
    public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketQuery, IEnumerable<TicketViewModel>>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public GetAllTicketsQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TicketViewModel>> Handle(GetAllTicketQuery request, CancellationToken cancellationToken)
        {
            var ticketEntities = await _ticketRepository.GetAll();
            var tickets = _mapper.Map<IEnumerable<TicketViewModel>>(ticketEntities);

            return tickets;
        }
    }
}

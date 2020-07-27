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
    public class GetSingleTicketHandler : IRequestHandler<GetSingleTicketQuery, TicketViewModel>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public GetSingleTicketHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<TicketViewModel> Handle(GetSingleTicketQuery request, CancellationToken cancellationToken)
        {
            var result = await _ticketRepository.GetTicketById(request.TicketId);
            var ticket = _mapper.Map<TicketViewModel>(result);
            return ticket;
        }
    }
}

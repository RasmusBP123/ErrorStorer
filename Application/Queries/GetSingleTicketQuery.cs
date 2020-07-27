using Application.ViewModels;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class GetSingleTicketQuery : IRequest<TicketViewModel>
    {
        public GetSingleTicketQuery(Guid ticketId)
        {
            TicketId = ticketId;
        }

        public Guid TicketId { get; }
    }
}

using Application.ViewModels;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class GetAllTicketQuery : IRequest<IEnumerable<TicketViewModel>>
    {
    }
}

using Application.ViewModels;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class DomainToViewModelMap : Profile
    {
        public DomainToViewModelMap()
        {
            CreateMap<Ticket, TicketViewModel>();
        }
    }
}

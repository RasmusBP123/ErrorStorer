using Application.ViewModels;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class ViewModelToDomainMap : Profile
    {
        public ViewModelToDomainMap()
        {
            CreateMap<TicketViewModel, Ticket>();
            CreateMap<CreateApplicationUserViewModel, ApplicationUser>();
            CreateMap<ApplicationUserViewModel, ApplicationUser>();
            CreateMap<LoginViewModel, ApplicationUser>();
        }
    }
}

using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels
{
    public class TicketViewModel
    {
        
        public Guid Id { get; set; }
        public string TicketNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketType Type { get; set; }
        public Status Status { get; set; }
        public IFormFile Files { get; set; }
    }
}

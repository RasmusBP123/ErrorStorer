using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class CreateTicketCommand : IRequest<bool>
    {
        public CreateTicketCommand(string title, string description, string ticketNumber, TicketType type, Status status, byte[] fileBytes)
        {
            Title = title;
            Description = description;
            TicketNumber = ticketNumber;
            Type = type;
            Status = status;
            FileBytes = fileBytes;
        }

        public string Title { get; }
        public string Description { get; }
        public string TicketNumber { get; }
        public TicketType Type { get; }
        public Status Status { get; }
        public byte[] FileBytes { get;  set;}
    }
}

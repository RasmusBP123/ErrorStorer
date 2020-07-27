using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace Domain
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string TicketNumber { get; set; }
        public ApplicationUser User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketType Type { get; set; }
        public Status Status { get; set; }
        public DateTime TimeStamp { get; set; }
        public List<File> Files { get; set; }

        public Ticket()
        {
                
        }

        public Ticket(string title, string ticketNumber, ApplicationUser user, string description, TicketType type, Status status, List<File> files)
        {
            Title = title;
            TicketNumber = ticketNumber;
            User = user;
            Description = description;
            Type = type;
            Status = status;
            Files = files;
            TimeStamp = DateTime.Now;
        }
    }


    public enum TicketType
    {
        Incident, 
        ServiceRequest, 
        Failure
    }

    public enum Status
    {
        [Display(Name = "Ready")]
        Active,
        [Display(Name = "Dead")]
        Closed,
        [Display(Name = "Purgatory")]
        Pending
    }
}

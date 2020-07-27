using Domain;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsTicketConstructed()
        {
            var ticket = new Ticket("Incident report", "st120", new ApplicationUser(), "It not working", TicketType.Incident, Status.Active);
            Assert.AreEqual(TicketType.Incident, ticket.Type);
        }
    }
}

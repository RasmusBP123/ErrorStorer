using Application.ViewModels;
using CsvHelper.Configuration;

namespace ErrorStorer.CsvMapper
{
    public class TicketCsvModel : ClassMap<TicketViewModel>
    {
        public TicketCsvModel()
        {
            Map(m => m.TicketNumber).Name("TicketNumber");
            Map(m => m.Description).Name("Describtion");
            Map(m => m.Title).Name("Title");
        }
    }
}

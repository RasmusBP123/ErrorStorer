using Application.ViewModels;
using CsvHelper;
using CsvHelper.Configuration;
using Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorStorer.CsvMapper
{
    public class CsvConverter
    {
        public void Main(List<TicketViewModel> tickets)
        {
            //using (var writer = new StreamWriter("Downloads"))
            //using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            //{
            //    csv.WriteRecords(tickets);
            //}
        }
    }
}

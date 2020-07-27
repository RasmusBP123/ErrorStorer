using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class File
    {
        public Guid Id { get; set; }
        public string FileType { get; set; }
        public byte[] Stream { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

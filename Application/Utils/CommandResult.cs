using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Utils
{
    public class CommandResult
    {
        public bool Successed { get; set; }
        public List<string> Errors { get; set; }
    }
}

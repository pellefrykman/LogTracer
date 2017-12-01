using System;
using System.Collections.Generic;
using System.Text;

namespace myApp
{
    public class LogEntryInformation
    {
        public DateTime TimeStamp { get; set; }
        public string EventType { get; set; }
        public string EventKey { get; set; }

        public string ConvertToJson()
        {
            return "";
        }
    }
}

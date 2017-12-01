using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace myApp
{
    public class LogEntryTransformer
    {
        private static string defaultTimestampPattern = @"^(?<timestamp>\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}.\d{3})";
        private static string timestampGroupKey = "timestamp";
        private static string valueGroupKey = "value";

        private Regex timestampRegex = new Regex(defaultTimestampPattern);
        private string type;
        private Regex keyRegex;

        public LogEntryTransformer(string eventType, string keyPattern)
        {
            type = eventType;
            keyRegex = new Regex(keyPattern);
        }

        public LogEntryInformation Transform(string logEntry)
        {
            LogEntryInformation logEntryInfo = new LogEntryInformation()
            {
                TimeStamp = DateTime.Parse(timestampRegex.Match(logEntry).Groups[timestampGroupKey].Value),
                EventType = type,
                EventKey = keyRegex.Match(logEntry).Groups[valueGroupKey].Value,
            };

            return logEntryInfo;
        }
    }
}

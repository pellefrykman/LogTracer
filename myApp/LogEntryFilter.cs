using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace myApp
{
    public class LogEntryFilter
    {
        private Regex regex;
        Action<string> nextBucket;

        public LogEntryFilter(string pattern, Action<string> nextBucket)
        {
            regex = new Regex(pattern);
            this.nextBucket = nextBucket;
        }

        public void process(string entry)
        {
            if (regex.IsMatch(entry))
            {
                nextBucket(entry);
            }
        }
    }
}

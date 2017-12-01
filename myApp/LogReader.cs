using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace myApp
{
    public class LogReader
    {
        private StreamReader reader;
        private Thread readerThread;
        private bool shouldStop = false;

        public List<string> Entries = new List<string>();

        public LogReader(StreamReader sr)
        {
            reader = sr;
            SetupThread();
        }

        public void StartReading() {
            readerThread.Start();
        }

        public void StopReading() {
            shouldStop = true;
            readerThread.Join();
        }

        private void SetupThread() {
            readerThread = new Thread(() => {
                while (!shouldStop)
                {
                    while (MoreEntriesAvailable())
                    {
                        string entry = GetNextEntry();
                        Entries.Add(entry);
                    }
                    Thread.Sleep(500);
                }
            });
        }

        private bool MoreEntriesAvailable()
        {
            return !reader.EndOfStream || !string.IsNullOrEmpty(nextLine);
        }

        private Regex multiLineRegex = new Regex(@"\d{4}-\d{2}-\d{2}", RegexOptions.IgnoreCase);
        private string nextLine = "";
        private string GetNextEntry()
        {
            StringBuilder entry = new StringBuilder();
            if (string.IsNullOrEmpty(nextLine))
            {
                entry.Append(reader.ReadLine());
            } else
            {
                entry.Append(nextLine);
                nextLine = string.Empty;
            }
            while (!reader.EndOfStream)
            {
                nextLine = reader.ReadLine();
                if (multiLineRegex.IsMatch(nextLine))
                {
                    break;
                } else
                {
                    entry.AppendLine();
                    entry.Append(nextLine);
                    nextLine = string.Empty;
                }
            }
            return entry.ToString();
        }
    }
}

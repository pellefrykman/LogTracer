using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;

namespace myAppTests
{
    public class LogStreamProducer
    {
        private List<string> testLogEntries = new List<string>() {
            "Log entry 1",
            "Log entry 2",
            "Log entry 3",
            "Log entry 4",
            "Log entry 5",
        };

        private Timer timer;

        public void StartTestLogEntriesToStream(StreamWriter writer) {
            StartWriteLogLogEntriesToStream(writer, testLogEntries);
        }

        public void StartISsLogEntriesToStream(StreamWriter writer) {
            StartWriteLogLogEntriesToStream(writer, TestData.ISsLogEntries);
        }

        private void StartWriteLogLogEntriesToStream(StreamWriter writer, List<string> entries)
        {
            int i = 0;
            timer = new Timer(200);
            timer.Elapsed += (sender, e) => {
                writer.WriteLine(entries[i]);
                writer.Flush();
                i++;
                if (i >= entries.Count) {
                    timer.Stop();
                }
            };
            timer.Start();
        }

        public bool IsWriting() {
            return timer.Enabled;
        }
    }
}

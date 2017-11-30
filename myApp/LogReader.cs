using System;
using System.IO;
using System.Threading;

namespace myApp
{
    public class LogReader
    {
        private StreamReader reader;
        private Thread readerThread;

        public LogReader(StreamReader sr)
        {
            reader = sr;
            SetupTimer();
        }

        public void StartReading() {
        }

        public void StopReading() {
        }

        private void SetupTimer() {
            readerThread = new Thread(() => {});

        }
    }
}

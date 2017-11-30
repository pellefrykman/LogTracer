using System;
using System.IO;

namespace myAppTests
{
    public class PipeStream
    {
        private MemoryStream memoryStream = new MemoryStream();
        private StreamReader reader;
        private StreamWriter writer;
        private long writePosition = 0;
        private long readPosition = 0;

        public long Length => memoryStream.Length;

        public bool ReadEndOfStream {
            get => reader.EndOfStream;
        }

        public PipeStream() {
            reader = new StreamReader(memoryStream);
            writer = new StreamWriter(memoryStream);
        }

        public void Flush()
        {
            lock (memoryStream)
            {
                memoryStream.Flush();
            }
        }

        public string ReadLine() {
            lock (memoryStream) {
                memoryStream.Position = readPosition;
                string result = reader.ReadLine();
                readPosition = memoryStream.Position;
                return result;
            }
            
        }

        public void WriteLine(string text) {
            lock (memoryStream)
            {
                memoryStream.Position = writePosition;
                writer.WriteLine(text);
                writer.Flush();
                writePosition = memoryStream.Position;
            }
        }
    }
}

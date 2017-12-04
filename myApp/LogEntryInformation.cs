using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text;

namespace myApp
{
    public class LogEntryInformation
    {
        private string id = Guid.NewGuid().ToString();
        public DateTime TimeStamp { get; set; }
        public string EventType { get; set; }
        public string EventKey { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Id { get => id; set => id = value; }
    }
}

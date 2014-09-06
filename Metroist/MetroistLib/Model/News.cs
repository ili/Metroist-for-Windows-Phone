using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MetroistLib.Model
{
    [DataContract]
    public class NewsItem
    {
        [DataMember]
        public double timestamp { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string category { get; set; }
        [DataMember]
        public string content { get; set; }
    }
}

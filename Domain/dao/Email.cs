using System;
using Newtonsoft.Json;

namespace Domain.dao {
    public class Email
    {
        public Guid id { get; set; }
        public string address { get; set;}

        [JsonConstructor]
        public Email()
        {
            
        }
    }
}
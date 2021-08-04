using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.dao
{
    public class User
    {
        public Guid id { get; set; }
        public String userName { get; set; }
        public String password { get; set; }

        public List<Address> addresses { get; set; }
        public List<Email> emails { get; set; }
        
        [JsonConstructor]
        public User()
        {
        }
    }
}
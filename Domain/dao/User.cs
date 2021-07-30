using System;
using System.Collections.Generic;

namespace Domain.dao
{
    public class User
    {
        public Guid id { get; set; }
        public String userName { get; set; }
        public String password { get; set; }

        public IEnumerable<Address> addresses { get; set; }
        public IEnumerable<Email> emails { get; set; }
        public User()
        {

        }
    }
}
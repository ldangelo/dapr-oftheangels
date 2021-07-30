using System;

namespace Domain.dao
{
    public class Address
    {
        public enum AddressType
        {
            Home, Work, Other
        };
        public Guid id { get; set; }

        public AddressType type { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
    }
}
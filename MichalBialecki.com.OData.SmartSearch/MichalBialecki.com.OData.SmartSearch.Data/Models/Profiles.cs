using System;
using System.Collections.Generic;

namespace MichalBialecki.com.OData.SmartSearch.Data.Models
{
    public partial class Profiles
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string CompanyName { get; set; }
        public string Notes { get; set; }
    }
}

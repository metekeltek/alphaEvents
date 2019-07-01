using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace alphaEventViewer.Models
{
    [Table("JobContactConfirmations")]
    public class JobContactConfirmationEntity
    {
        [ExplicitKey]
        public Guid JobContactId { get; set; }
        public Guid EventItemId { get; set; }
        public string Salutation { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMailAddress { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public bool Confirmed { get; set; }
    }
}

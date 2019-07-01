using System;
using Dapper.Contrib.Extensions;


namespace alphaEventViewer.Models
{
    [Table("JobEventRegistrations")]
    public class JobEventRegistrationEntity
    {
        [ExplicitKey]
        public Guid JobEventRegistrationId { get; set; }
        public Guid JobId { get; set; }
        public Guid ParticipantJobContactId { get; set; }
        public Guid EventItemId { get; set; }
        public string Role { get; set; }
        public string State { get; set; }
    }
}

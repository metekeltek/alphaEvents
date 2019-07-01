using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace alphaEventViewer.Models
{
    [Table("Jobs")]
    public class JobEntity
    {
        [ExplicitKey]
        public Guid JobId { get; set; }
        public string JobType { get; set; }
        public string Caption { get; set; }
        public DateTime TimeOfReceipt { get; set; } = DateTime.Now;
        public string ShortDescription { get; set; }
        public string State { get; set; }
        public DateTime StateTime { get; set; } = DateTime.Now;
        public string FullDescription { get; set; }
    }
}

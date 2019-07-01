using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace alphaEventViewer.Models
{
    public class ModuleEntity
    {
        [ExplicitKey]
        public Guid? EventItemId { get; set; }

        public Guid? RootId { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public DateTime? Beginning { get; set; }
        public DateTime? End { get; set; }
        public decimal TeachingUnits { get; set; }
        public string EventType { get; set; }
     
      

    }
}
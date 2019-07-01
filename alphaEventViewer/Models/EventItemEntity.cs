using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace alphaEventViewer.Models
{
    [Table("EventItems")]
    public class EventItemEntity
    {
        [ExplicitKey]
        public Guid? EventItemId { get; set; }

        public string SerialNumber { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public DateTime? Beginning { get; set; }
        public DateTime? End { get; set; }
        public decimal TeachingUnits { get; set; }
        public string EventType { get; set; }
        public string SubjectArea { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public DateTime? RegistrationStart { get; set; }
        public DateTime? ClosingDate { get; set; }
        public string Location { get; set; }
        public DateTime? CancellationDeadline { get; set; }
        public string Room { get; set; }
        public string Director { get; set; }
        public string Administrator { get; set; }
        public bool TaxIsIncluded { get; set; }
        public decimal TaxRate { get; set; }
        public decimal DefaultPrice { get; set; }
        public string Currency { get; set; }
        public decimal EarlyBirdPrice { get; set; }
        public DateTime? EarlyBirdDeadline { get; set; }
        public bool IsCancelled { get; set; }
        public DateTime? CancellationDate { get; set; }
        public string Notes { get; set; }

        public IEnumerable<EventItemEntity> Modules { get; set; }

        [Computed]
        public decimal ComputedPrice => TaxIsIncluded ? DefaultPrice : DefaultPrice + DefaultPrice * (TaxRate / 100);

        [Computed]
        public string FullPrice => ComputedPrice.ToString("C");

    }
}
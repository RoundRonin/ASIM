using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InventoryObject
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Location { get; set; }
        public string Condition { get; set; }
        public string QrCode { get; set; }

        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
        public ICollection<RepairRequest> RepairRequests { get; set; } = new List<RepairRequest>();
        public ICollection<LogEntry> LogEntries { get; set; } = new List<LogEntry>();
        public AdditionalObjectDetails AdditionalDetails { get; set; }
    }
}

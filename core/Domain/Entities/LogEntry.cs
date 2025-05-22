using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LogEntry
    {
        public int LogId { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ObjectId { get; set; }
        public InventoryObject InventoryObject { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RepairRequest
    {
        public int RequestId { get; set; }
        public string Description { get; set; }
        public string Status {  get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int ObjectId { get; set; }
        public InventoryObject InventoryObject { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rental
    {
        public int RentalId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

        public int ObjectId { get; set; }
        public InventoryObject InventoryObject { get; set; }

        public int RenterId { get; set; }
        public User Renter { get; set; }
    }
}

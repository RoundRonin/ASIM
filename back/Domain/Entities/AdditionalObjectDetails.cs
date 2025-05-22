using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AdditionalObjectDetails
    {
        public int DetailsId { get; set; }
        public int ObjectId { get; set; }

        public string Description { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Warranty { get; set; }
        public string TechnicalSpecifications { get; set; }

        public InventoryObject InventoryObject { get; set; }
    }

}

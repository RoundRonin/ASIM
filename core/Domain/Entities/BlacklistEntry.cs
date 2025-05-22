using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BlacklistEntry
    {
        public int BlacklistId { get; set; }
        public int UserId { get; set; }
        public DateTime RevokedAt { get; set; }
        public string Reason { get; set; }

        public User User { get; set; }
    }
}

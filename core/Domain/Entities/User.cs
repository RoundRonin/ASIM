using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
    public DateTime LastLogin { get; set; }

    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    public ICollection<RepairRequest> RepairRequests { get; set; } = new List<RepairRequest>();
    public ICollection<LogEntry> LogEntries { get; set; } = new List<LogEntry>();
    public ICollection<BlacklistEntry> BlacklistEntries { get; set; } = new List<BlacklistEntry>();
}

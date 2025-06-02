
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class InventoryObject
{
    public Guid ItemId { get; init; }  
    public string Name { get; init; }
    public string SerialNumber { get; init; }
    public string Location { get; init; }
    public string Condition { get; init; }
    public string QrCode { get; init; }
        
    public int? ItemTypeId { get; init; }  

    public AdditionalObjectDetails AdditionalDetails { get; init; }

    public ICollection<Rental> Rentals { get; init; } = new List<Rental>();
    public ICollection<RepairRequest> RepairRequests { get; init; } = new List<RepairRequest>();
    public ICollection<LogEntry> LogEntries { get; init; } = new List<LogEntry>();
}
using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class MachineMaster
{
    public long MachineId { get; set; }

    public string? MachineName { get; set; }

    public string? MachineSerialNumber { get; set; }

    public long? MachineManufacturerId { get; set; }

    public string? MachineModel { get; set; }

    public short? YearofManufacture { get; set; }

    public int? MachineType { get; set; }

    public long? LoactionId { get; set; }
}

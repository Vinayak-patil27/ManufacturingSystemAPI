using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class ComponentOperationMaster
{
    public long TrNo { get; set; }

    public long ComponentId { get; set; }

    public long? MachineId { get; set; }

    public string? OperationCode { get; set; }

    public string? OperationName { get; set; }

    public string? OperationDescription { get; set; }

    public int? OperationType { get; set; }
}

namespace WebAPI.ViewModels
{
    public class OperationDetailsViewModel
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public long? ComponentId { get; set; }
        public string? ComponentName { get; set; }
        public string? PartNo { get; set; }
        public string? ECN { get; set; }
        public long? TrNo { get; set; }
        public string? OperationCode { get; set; }
        public string? OperationName { get; set; }
        public string? OperationDescription { get; set; }
        public int? OperationType { get; set; }
        public long? MachineId { get; set; }
        public string? MachineName { get; set; }
    }
}


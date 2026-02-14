namespace WebAPI.Models
{
    public enum MachineType
    {
        CNC_Turning_Center = 1,
        VMC = 2,
        HMC = 3,
        HBM = 4,
        VTL = 5,
        Five_Axis_Machining_Center = 6
    }

    public enum OperationType
    {
        Turning = 1,
        Milling = 2,
        Drilling = 3,
        Chamfering = 4,
        Tapping = 5,
        Threading = 6,
        Boring = 7,
        Knurling = 8,
        Honing = 9,
        Buffing = 10
    }
}

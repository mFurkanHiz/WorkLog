namespace WorkLog.Models.ViewModel
{
    public class OperationLog
    {
        public int Id { get; set; } = ++len; // Id is bults by the incriment of len
        public DateTime StartingTime { get; set; }
        public DateTime FinishingTime { get; set; }
        public TimeSpan ProcessedTime => FinishingTime - StartingTime;
        public string Status { get; set; }
        public string? Details { get; set; }
        public static int len { get; set; } = 0; // Total amount of the usage of this class
    }
}

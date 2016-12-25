namespace Email.Repository
{
    public enum QueueStatus
    {
        InQueue = 0,
        Initializing = 1,
        InProgress = 2,
        Failed = 3,
        Completed = 4
    }
}

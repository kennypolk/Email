namespace Email.Repository.Interfaces
{
    public interface IEmailQueueRepository<T> : IRepository<T> where T : IEmailQueue
    {
        T Peek();
    }
}

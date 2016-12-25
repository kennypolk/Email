using System.Collections.Generic;
using Email.Repository.Interfaces;

namespace Email.Service.Interfaces
{
    public interface IEmailQueueService<T> where T : IEmailQueue
    {
        T Get(int id);
        List<T> Get();
        T Dequeue();
        int? Enqueue(T item);
        void Finalize(T item);
    }
}

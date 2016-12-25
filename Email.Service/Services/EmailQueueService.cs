using System;
using System.Collections.Generic;
using Email.Repository;
using Email.Repository.Interfaces;
using Email.Service.Interfaces;

namespace Email.Service.Services
{
    public class EmailQueueService<T> : IEmailQueueService<T> where T : IEmailQueue
    {
        private readonly IEmailQueueRepository<T> repository;

        public EmailQueueService(IEmailQueueRepository<T> repository)
        {
            this.repository = repository;
        }

        public T Get(int id)
        {
            return repository.Get(id);
        }

        public List<T> Get()
        {
            return repository.Get();
        }

        public T Dequeue()
        {
            var item = default(T);

            for (var i = 0; i < 500; i++)
            {
                item = repository.Peek();
                if (item == null)
                {
                    break;
                }

                item.Status = QueueStatus.InProgress;

                var result = repository.Update(item);
                if (result > 0)
                {
                    break;
                }
            }

            return item;
        }

        public int? Enqueue(T item)
        {
            item.SubmittedDate = DateTime.Now;
            return repository.Insert(item);
        }

        public void Finalize(T item)
        {
            if (item.Status == QueueStatus.Failed)
            {
                repository.Update(item);
            }
            else
            {
                repository.Delete(item);
            }
        }
    }
}

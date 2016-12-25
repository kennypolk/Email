using System;
using Email.Repository.Interfaces;

namespace Email.Repository.Repository
{
    public class EmailQueueRepository<T> : Repository<T>, IEmailQueueRepository<T> where T : IEmailQueue
    {
        public EmailQueueRepository(IRepositoryConfiguration repositoryConfiguration) : base(repositoryConfiguration)
        {
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }
    }
}

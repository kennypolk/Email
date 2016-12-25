using Email.Repository.Entities;
using Email.Repository.Interfaces;

namespace Email.Repository.Repository
{
    public class HotlistDetailEmailQueueRepository : EmailQueueRepository<HotlistDetailEmailQueue>, IHotlistDetailEmailQueueRepository
    {
        public HotlistDetailEmailQueueRepository(IRepositoryConfiguration repositoryConfiguration) : base(repositoryConfiguration)
        {
        }
    }
}

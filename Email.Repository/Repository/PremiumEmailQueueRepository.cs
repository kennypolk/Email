using Email.Repository.Entities;
using Email.Repository.Interfaces;

namespace Email.Repository.Repository
{
    public class PremiumEmailQueueRepository : EmailQueueRepository<PremiumEmailQueue>, IPremiumEmailQueueRepository
    {
        public PremiumEmailQueueRepository(IRepositoryConfiguration repositoryConfiguration) : base(repositoryConfiguration)
        {
        }
    }
}

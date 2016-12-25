using Email.Repository.Entities;
using Email.Repository.Interfaces;

namespace Email.Repository.Repository
{
    public class WelcomeEmailQueueRepository : EmailQueueRepository<WelcomeEmailQueue>, IWelcomeEmailQueueRepository
    {
        public WelcomeEmailQueueRepository(IRepositoryConfiguration repositoryConfiguration) : base(repositoryConfiguration)
        {
        }
    }
}

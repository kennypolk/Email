using Email.Repository.Entities;
using Email.Repository.Interfaces;

namespace Email.Repository.Repository
{
    public class RecurringCampaignEmailQueueRepository : EmailQueueRepository<RecurringCampaignEmailQueue>, IRecurringCampaignEmailQueueRepository
    {
        public RecurringCampaignEmailQueueRepository(IRepositoryConfiguration repositoryConfiguration) : base(repositoryConfiguration)
        {
        }
    }
}

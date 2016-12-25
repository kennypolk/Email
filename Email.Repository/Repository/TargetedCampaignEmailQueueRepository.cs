using Email.Repository.Entities;
using Email.Repository.Interfaces;

namespace Email.Repository.Repository
{
    public class TargetedCampaignEmailQueueRepository : EmailQueueRepository<TargetedCampaignEmailQueue>, ITargetedCampaignEmailQueueRepository
    {
        public TargetedCampaignEmailQueueRepository(IRepositoryConfiguration repositoryConfiguration) : base(repositoryConfiguration)
        {
        }
    }
}

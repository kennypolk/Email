using Email.Repository.Entities;
using Email.Repository.Interfaces;
using Email.Service.Interfaces;

namespace Email.Service.Services
{
    public class TargetedCampaignEmailQueueService : EmailQueueService<TargetedCampaignEmailQueue>, ITargetedCampaignEmailQueueService
    {
        public TargetedCampaignEmailQueueService(ITargetedCampaignEmailQueueRepository repository) : base(repository)
        {
        }
    }
}

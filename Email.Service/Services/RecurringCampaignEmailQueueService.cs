using Email.Repository.Entities;
using Email.Repository.Interfaces;
using Email.Service.Interfaces;

namespace Email.Service.Services
{
    public class RecurringCampaignEmailQueueService : EmailQueueService<RecurringCampaignEmailQueue>, IRecurringCampaignEmailQueueService
    {
        public RecurringCampaignEmailQueueService(IRecurringCampaignEmailQueueRepository repository) : base(repository)
        {
        }
    }
}

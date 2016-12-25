using Email.Repository.Entities;

namespace Email.Service.Interfaces
{
    public interface IRecurringCampaignEmailQueueService : IEmailQueueService<RecurringCampaignEmailQueue>
    {
    }
}

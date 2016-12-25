using Email.Repository.Entities;

namespace Email.Service.Interfaces
{
    public interface ITargetedCampaignEmailQueueService : IEmailQueueService<TargetedCampaignEmailQueue>
    {
    }
}

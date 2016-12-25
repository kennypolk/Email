using Email.Repository.Entities;

namespace Email.Repository.Interfaces
{
    public interface ITargetedCampaignEmailQueueRepository : IEmailQueueRepository<TargetedCampaignEmailQueue>
    {
    }
}

using Email.Repository.Entities;
using Email.Repository.Interfaces;
using Email.Service.Interfaces;

namespace Email.Service.Services
{
    public class PremiumEmailQueueService : EmailQueueService<PremiumEmailQueue>, IPremiumEmailQueueService
    {
        public PremiumEmailQueueService(IPremiumEmailQueueRepository repository) : base(repository)
        {
        }
    }
}

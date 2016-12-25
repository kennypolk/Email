using Email.Repository.Entities;
using Email.Repository.Interfaces;
using Email.Service.Interfaces;

namespace Email.Service.Services
{
    public class WelcomeEmailQueueService : EmailQueueService<WelcomeEmailQueue>, IWelcomeEmailQueueService
    {
        public WelcomeEmailQueueService(IWelcomeEmailQueueRepository repository) : base(repository)
        {
        }
    }
}

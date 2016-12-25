using Email.Repository.Entities;

namespace Email.Service.Interfaces
{
    public interface IWelcomeEmailQueueService : IEmailQueueService<WelcomeEmailQueue>
    {
    }
}

using Email.Repository.Entities;

namespace Email.Repository.Interfaces
{
    public interface IWelcomeEmailQueueRepository : IEmailQueueRepository<WelcomeEmailQueue>
    {
    }
}

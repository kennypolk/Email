using Email.Repository.Entities;

namespace Email.Service.Interfaces
{
    public interface IResetPasswordEmailQueueService : IEmailQueueService<ResetPasswordEmailQueue>
    {
    }
}

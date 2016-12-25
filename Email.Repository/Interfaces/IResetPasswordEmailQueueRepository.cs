using Email.Repository.Entities;

namespace Email.Repository.Interfaces
{
    public interface IResetPasswordEmailQueueRepository : IEmailQueueRepository<ResetPasswordEmailQueue>
    {
    }
}

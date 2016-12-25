using Email.Repository.Entities;
using Email.Repository.Interfaces;
using Email.Service.Interfaces;

namespace Email.Service.Services
{
    public class ResetPasswordEmailQueueService : EmailQueueService<ResetPasswordEmailQueue>, IResetPasswordEmailQueueService
    {
        public ResetPasswordEmailQueueService(IResetPasswordEmailQueueRepository repository) : base(repository)
        {
        }
    }
}

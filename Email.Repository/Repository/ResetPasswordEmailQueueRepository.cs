using Email.Repository.Entities;
using Email.Repository.Interfaces;

namespace Email.Repository.Repository
{
    public class ResetPasswordEmailQueueRepository : EmailQueueRepository<ResetPasswordEmailQueue>, IResetPasswordEmailQueueRepository
    {
        public ResetPasswordEmailQueueRepository(IRepositoryConfiguration repositoryConfiguration) : base(repositoryConfiguration)
        {
        }
    }
}

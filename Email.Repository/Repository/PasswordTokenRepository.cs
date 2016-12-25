using Email.Repository.Entities;
using Email.Repository.Interfaces;

namespace Email.Repository.Repository
{
    public class PasswordTokenRepository : Repository<PasswordToken>, IPasswordTokenRepository
    {
        public PasswordTokenRepository(IRepositoryConfiguration repositoryConfiguration) : base(repositoryConfiguration)
        {
        }
    }
}

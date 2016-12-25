using Email.Repository.Entities;
using Email.Repository.Interfaces;

namespace Email.Repository.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(IRepositoryConfiguration repositoryConfiguration) : base(repositoryConfiguration)
        {
        }
    }
}

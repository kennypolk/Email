using Email.Repository.Interfaces;

namespace Email.Repository
{
    public class RepositoryConfiguration : IRepositoryConfiguration
    {
        public string ConnectionString { get; set; }
    }
}

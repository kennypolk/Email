using Email.Repository.Entities;

namespace Email.Service.Interfaces
{
    public interface IPremiumEmailService : IEmailService<PremiumEmailQueue>
    {
    }
}

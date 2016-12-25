using Email.Repository.Entities;
using Email.Repository.Interfaces;
using Email.Service.Interfaces;

namespace Email.Service.Services
{
    public class HotlistDetailEmailQueueService : EmailQueueService<HotlistDetailEmailQueue>, IHotlistDetailEmailQueueService
    {
        public HotlistDetailEmailQueueService(IHotlistDetailEmailQueueRepository repository) : base(repository)
        {
        }
    }
}

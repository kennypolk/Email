using Email.Repository.Entities;
using Email.Repository.Interfaces;
using Email.Service.Interfaces;

namespace Email.Service.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository templateRepository;

        public TemplateService(ITemplateRepository templateRepository)
        {
            this.templateRepository = templateRepository;
        }

        public Template Get(int id)
        {
            return templateRepository.Get(id);
        }
    }
}

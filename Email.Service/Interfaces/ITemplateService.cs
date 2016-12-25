using Email.Repository.Entities;

namespace Email.Service.Interfaces
{
    public interface ITemplateService
    {
        Template Get(int id);
    }
}

namespace Email.Service.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(int templateId, string emailExtensionField);
    }
}

using System.Collections.Generic;

namespace Email.Service.Interfaces
{
    public interface IExactTargetService
    {
        void CheckStatus();
        ETServiceClient.ETClient.Email GetEmail(int id);
        void SendEmail(int templateId, List<Dictionary<string, string>> mergeCodes, string emailExtensionField, string emailSubject);
    }
}

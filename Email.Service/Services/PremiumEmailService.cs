using Email.Repository;
using Email.Repository.Entities;
using Email.Service.Interfaces;

namespace Email.Service.Services
{
    public class PremiumEmailService : IPremiumEmailService
    {
        private readonly ITemplateService templateService;
        private readonly IMergeCodeService mergeCodeService;
        private readonly IExactTargetService exactTargetService;
        private readonly IPremiumEmailQueueService premiumEmailQueueService;

        public PremiumEmailService(ITemplateService templateService, IMergeCodeService mergeCodeService, IExactTargetService exactTargetService, IPremiumEmailQueueService premiumEmailQueueService)
        {
            this.templateService = templateService;
            this.mergeCodeService = mergeCodeService;
            this.exactTargetService = exactTargetService;
            this.premiumEmailQueueService = premiumEmailQueueService;
        }

        public void SendEmail(PremiumEmailQueue item)
        {
            //    //Get template, check Active
            var template = templateService.Get(item.TemplateId);
            if (template == null)
            {
                //TODO: Template is not found
                return;
            }

            if (!template.IsActive)
            {
                //TODO: Template is not active
                return;
            }

            var email = exactTargetService.GetEmail(template.MassEmailId);

            //    //Check ContentAreas

            var mergeCodes = mergeCodeService.GetMergeCodes();

            exactTargetService.SendEmail(email.ID, mergeCodes, "MR_TargetEmail", email.Subject);

            //    //EmailSendLogData
            //    //Update EmailRequestQueue
        }

    }
}

using System;
using Email.Repository.Interfaces;
using Email.Service.Interfaces;

namespace Email.Service.Services
{
    public class EmailService : IEmailService
    { 
        private readonly ITemplateService templateService;
        private readonly IMergeCodeService mergeCodeService;
        private readonly IExactTargetService exactTargetService;

        public EmailService(ITemplateService templateService, IMergeCodeService mergeCodeService, IExactTargetService exactTargetService)
        {
            this.templateService = templateService;
            this.mergeCodeService = mergeCodeService;
            this.exactTargetService = exactTargetService;
        }

        public void SendEmail(int templateId, string emailExtensionField)
        {
            var template = templateService.Get(templateId);
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

            exactTargetService.SendEmail(email.ID, mergeCodes, emailExtensionField, email.Subject);

            //    //EmailSendLogData
            //    //Update EmailRequestQueue
        }
    }
}

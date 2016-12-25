using System;

namespace Email.Repository.Interfaces
{
    public interface IEmailQueue
    {
        int AccountId { get; set; }
        QueueStatus Status { get; set; }
        string StatusMessage { get; set; }
        int Retry { get; set; }
        DateTime SubmittedDate { get; set; }
        DateTime? StartDate { get; set; }
        int TemplateId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Email.Repository.Interfaces;

namespace Email.Repository.Entities
{
    public abstract class EmailQueue : IEmailQueue
    {
        public int AccountId { get; set; }
        public QueueStatus Status { get; set; }
        public string StatusMessage { get; set; }
        public int Retry { get; set; }
        public DateTime SubmittedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public int TemplateId { get; set; }
    }
}

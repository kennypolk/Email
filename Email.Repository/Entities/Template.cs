namespace Email.Repository.Entities
{
    public class Template
    {
        public int TemplateId { get; set; }
        public int MassEmailId { get; set; }
        public bool IsActive { get; set; }
    }
}

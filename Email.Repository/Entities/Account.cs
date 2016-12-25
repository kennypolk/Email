namespace Email.Repository.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public bool Brand { get; set; }
        public bool CustomWelcomeEmailEnabled { get; set; }
        public int CustomWelcomeEmailId { get; set; }
        public bool CustomResetPasswordEmailEnabled { get; set; }
        public int CustomResetPasswordEmailId { get; set; }
    }
}

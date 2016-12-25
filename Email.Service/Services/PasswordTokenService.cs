using Email.Repository.Entities;
using Email.Repository.Interfaces;
using Email.Service.Interfaces;

namespace Email.Service.Services
{
    public class PasswordTokenService : IPasswordTokenService
    {
        private readonly IPasswordTokenRepository passwordTokenRepository;

        public PasswordTokenService(IPasswordTokenRepository passwordTokenRepository)
        {
            this.passwordTokenRepository = passwordTokenRepository;
        }

        PasswordToken IPasswordTokenService.Get(int id)
        {
            return passwordTokenRepository.Get(id);
        }

        int? IPasswordTokenService.Insert(PasswordToken token)
        {
            return passwordTokenRepository.Insert(token);
        }

        int IPasswordTokenService.Update(PasswordToken token)
        {
            return passwordTokenRepository.Update(token);
        }
    }
}

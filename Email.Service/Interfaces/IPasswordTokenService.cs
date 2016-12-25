using Email.Repository.Entities;

namespace Email.Service.Interfaces
{
    public interface IPasswordTokenService
    {
        PasswordToken Get(int id);
        int? Insert(PasswordToken token);
        int Update(PasswordToken token);
    }
}

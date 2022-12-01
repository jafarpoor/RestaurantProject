using Application.DTO;
using Application.Users.DTO;

namespace Application.Interfaces.Users
{
   public interface IEditUserService
    {
        ResultDataModel Edit(EditUserDataModel editUserDataModel);
    }
}

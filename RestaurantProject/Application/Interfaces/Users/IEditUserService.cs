using Application.PagerConfig;
using Application.Users.DTO;

namespace Application.Interfaces.Users
{
   public interface IEditUserService
    {
        ResultServices Edit(EditUserDataModel editUserDataModel);
    }
}

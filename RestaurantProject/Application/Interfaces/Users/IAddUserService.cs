using Application.PagerConfig;
using Application.Users.DTO;

namespace Application.Users.Commands.AddUser
{
   public interface IAddUserService 
    {
        ResultServices Creat(RegisterDataModel model);
    }
}

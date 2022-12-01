
using Application.DTO;
using Application.Users.DTO;

namespace Application.Users.Commands.AddUser
{
   public interface IAddUserService 
    {
        ResultDataModel Creat(RegisterDataModel model);
    }
}

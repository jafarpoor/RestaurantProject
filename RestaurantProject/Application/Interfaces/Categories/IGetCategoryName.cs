using Application.DTO;

namespace Application.Interfaces.Categories
{
   public interface IGetCategoryName
    {
        ResultDataModel<string> GetName(int ParentId);
    }
}

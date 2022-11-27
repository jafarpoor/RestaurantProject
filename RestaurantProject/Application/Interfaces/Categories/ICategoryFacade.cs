
namespace Application.Interfaces.Categories
{
    public interface ICategoryFacade
    {
        IAddCategoryService addCategory { get; }
        IGetListCategoyService getListCategoyService { get; }
        IAddCategoryItemService addCategoryItemService  {get;}
        IGetListCategoryItemService getListCategoryItemService { get; }
        IGetCategoryName getCategoryName { get; }
    }
}

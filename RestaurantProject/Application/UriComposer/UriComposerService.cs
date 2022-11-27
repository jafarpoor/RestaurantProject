
namespace Application.UriComposer
{
   public class UriComposerService : IUriComposerService
    {
        public string ComposeImageUri(string URl)
        {
            return "https://localhost:44331/" + URl.Replace("\\", "//");
        }
    }
}

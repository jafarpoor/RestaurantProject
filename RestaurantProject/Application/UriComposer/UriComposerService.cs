using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

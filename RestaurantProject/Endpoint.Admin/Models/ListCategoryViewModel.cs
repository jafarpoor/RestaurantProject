using Application.Categories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Admin.Models
{
    public class ListCategoryViewModel
    {
        public List<ListCategoryItemDataModel> listCategoryItemDataModels { get; set; }
        public List<string> columnsName { get; set; }
    }
}

using Application.Categories.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Admin.Models
{
    public class AddCategoryItemViewModel
    {
        public IFormFile Files { get; set; }
        public  AddCategoryItemDataModel addCategoryItemDataModel { get; set; }
        public IEnumerable<SelectListItem> Caregories { get; set; }
    }
}

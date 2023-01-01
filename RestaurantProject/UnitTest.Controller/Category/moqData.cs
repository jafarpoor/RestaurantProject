using Application.Categories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Controller.Category
{
    public class moqData
    {
        public List<ListCategoryDataModel> GetAll()
        {
            List<ListCategoryDataModel> lists = new List<ListCategoryDataModel>();
            lists.Add(new ListCategoryDataModel()
            {
                Id = 1,
                Name = "Test1"
            });
            lists.Add(new ListCategoryDataModel()
            {
                Id = 1,
                Name = "Test2"
            });

            return lists;
        }
    }
}

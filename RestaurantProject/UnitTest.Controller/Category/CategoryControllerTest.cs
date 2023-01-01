using Application.Categories.DTO;
using Application.Interfaces.Categories;
using EndPoint.Admin.Controllers;
using Infrastructure.Api.ImageApi;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Controller.Category
{
    public class CategoryControllerTest
    {
        [Fact]
        public void Category_GetList()
        {
            ////Arrange
            moqData moq = new moqData();
        var moqCategory = new Mock<ICategoryFacade>();
        var moqImageUrl = new Mock<IImageUploadService>();
            moqCategory.Setup(p => p.getListCategoyService.GetListCategory()).Returns(moq.GetAll());

            CategoryController  categoryController = new CategoryController(moqCategory.Object  , moqImageUrl.Object);


            //Acat
            var result = categoryController.GetList();

            //Assert
            Assert.IsType<List<ListCategoryDataModel>>(result);

        }
    }
}

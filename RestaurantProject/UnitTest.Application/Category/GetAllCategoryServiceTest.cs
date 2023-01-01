using Application.Categories.Commands.AddCategories;
using Application.Categories.DTO;
using Application.Categories.Queries;
using AutoMapper;
using AutoMapper.Internal;
using Builders.Category;
using Infrastructure.AutoMapperConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Builders;
using Xunit;

namespace UnitTest.Application.Category
{
    public class GetAllCategoryServiceTest
    {
        [Fact]
        public void GetAll_Category()
        {

            //Arrange
            var dataBaseBuilder = new DatabaseBuilder();
            var dbConnection = dataBaseBuilder.GetDbContext();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CategoryMapperConfigs());
            });
            var mapper = mockMapper.CreateMapper();

            var categoryAddService = new AddCategoryService(dbConnection);

            AddCategoryDataModel c1 = new AddCategoryDataModel()
            {
               Name ="Test1"
            };

            AddCategoryDataModel c2 = new AddCategoryDataModel()
            {
               Name = "Test2"
            };

            categoryAddService.Add(mapper.Map<AddCategoryDataModel>(c1));
            categoryAddService.Add(mapper.Map<AddCategoryDataModel>(c2));

            //Acat
            var getCategorySerevice = new GetListCategoyService(dbConnection , mapper);
            var categoryResult = getCategorySerevice.GetListCategory().Data;

            //Assert
            Assert.Equal(2, categoryResult.Count);
            Assert.NotNull(categoryResult.Select(p=>p.Name));
        }
    }
}

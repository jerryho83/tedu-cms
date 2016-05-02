using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;
using TEDU.Model;
using TEDU.Service;

namespace TEDU.UnitTesting.ServiceTest
{
    [TestClass]
    public class CategoryServiceTest
    {
        private Mock<ICategoryRepository> _mockRepository;
        private ICategoryService _service;
        private Mock<IUnitOfWork> _mockUnitWork;
        private List<Category> _listCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<ICategoryRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new CategoryService(_mockRepository.Object, _mockUnitWork.Object);
            _listCategory = new List<Category>() {
               new Category() { ID = 1, Name = "US" },
               new Category() { ID = 2, Name = "India" },
               new Category() { ID = 3, Name = "Russia" }
          };
        }

        [TestMethod]
        public void Category_Get_All()
        {
            //Arrange
            _mockRepository.Setup(x => x.GetMany(c => c.Status)).Returns(_listCategory);

            //Act
            List<Category> results = _service.GetCategories() as List<Category>;

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }


    }
}
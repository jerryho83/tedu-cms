using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
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
        public void Category_Service_Get_All()
        {
            //Arrange
            _mockRepository.Setup(x => x.GetMulti(c => c.Status, null)).Returns(_listCategory.AsQueryable());

            //Act
            List<Category> results = _service.GetCategories() as List<Category>;

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }

        [TestMethod]
        public void Category_Service_Create()
         {
            //Arrange
            Category category = new Category() { Name = "abc" };
            int id = 1;
            _mockRepository.Setup(x => x.Add(category)).Returns((Category c)=> {
                c.ID = id;
                return c;
            }).Verifiable();

            _service.CreateCategory(category);

            Assert.AreEqual(id, category.ID);

            _mockUnitWork.Verify(m => m.Commit(), Times.Once);
        }
    }
}
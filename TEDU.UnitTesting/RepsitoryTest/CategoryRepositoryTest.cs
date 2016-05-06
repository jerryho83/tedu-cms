using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEDU.Data;
using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;
using TEDU.Model;

namespace TEDU.UnitTesting.RepsitoryTest
{
    [TestClass]
    public class CategoryRepositoryTest
    {
        DbFactory dbFactory;
        CategoryRepository objRepo;
        IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepo = new CategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);

        }
        [TestMethod]
        public void Category_Repository_Get_ALL()
        {
            //Act
            var result = objRepo.GetAll().ToList();

            //Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Count);
        }
        [TestMethod]
        public void Category_Repository_Create()
        {
            //Arrange
            Category c = new Category() { Name = "Test", ShowHome = false };

            //Act
            var result = objRepo.Add(c);
            unitOfWork.Commit();
            var lst = objRepo.GetAll().ToList();

            //Assert

            Assert.AreEqual(11, lst.Count);
            Assert.AreEqual("Test", lst.Last().Name);
        }
        [TestMethod]
        public void Category_Repository_Delete()
        {
            //Arrange
            Category c = new Category() { ID = 43, Name = "Test", ShowHome = false };

            //Act
            var result = objRepo.Delete(c);
            unitOfWork.Commit();
            var lst = objRepo.GetAll().ToList();

            //Assert
            Assert.IsNotNull(result);
           // Assert.AreEqual(10, lst.Count);
        }
    }
}

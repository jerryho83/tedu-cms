using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;

namespace TEDU.UnitTesting.RepsitoryTest
{
   [TestClass]
    public class CategoryRepositoryTest
    {
        DbFactory dbFactory;
        CategoryRepository objRepo;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            dbFactory.Init();
            objRepo = new CategoryRepository(dbFactory);

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

    }
}

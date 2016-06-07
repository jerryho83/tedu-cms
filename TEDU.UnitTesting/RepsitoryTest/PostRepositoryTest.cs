using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;

namespace TEDU.UnitTesting.RepsitoryTest
{
    [TestClass]
    public class PostRepositoryTest
    {
        DbFactory dbFactory;
        PostRepository objRepo;
        IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepo = new PostRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);

        }
        [TestMethod]
        public void Post_Repository_Get_ListPostByTag()
        {
            //Act
            int totalRow = 0;
            var result = objRepo.GetListPostByTag("appe",1,20,out totalRow).ToList();
            //Assert

            Assert.IsNotNull(result.Count>0);
        }
    }
}

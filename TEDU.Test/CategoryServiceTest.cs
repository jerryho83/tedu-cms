using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using TEDU.Service;

namespace TEDU.Test
{
    [TestClass]
    public class CategoryServiceTest
    {
        [TestMethod]
        public void TestGetCategories()
        {
            Mock<ICategoryService> mockCategory = new Mock<ICategoryService>();
            int totalRow;
            int count = mockCategory.Object.GetCategories(0, 1, out totalRow).Count();
            Assert.AreEqual(1, count);
        }
    }
}
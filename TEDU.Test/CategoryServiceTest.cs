using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEDU.Model;
using TEDU.Service;

namespace TEDU.Test
{
    [TestFixture]
    public class CategoryServiceTest
    {
        [TestCase]
        public void TestGetCategories()
        {
            Mock<ICategoryService> mockCategory = new Mock<ICategoryService>();
            int count = mockCategory.Object.GetCategories().Count();
            Assert.Equals(count, 1);
        }

    }
}

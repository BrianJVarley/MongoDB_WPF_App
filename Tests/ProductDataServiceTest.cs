using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDBApp.DAL;
using MongoDBApp.Models;
using MongoDBApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Mocks;

namespace Tests
{
    [TestClass]
    public class ProductDataServiceTest
    {

        private IRepository<ProductModel> repository;

        [TestInitialize]
        public void Init()
        {
            repository = new MockProductRespository();
        }


        [TestMethod]
        public void GetAllProductsTest()
        {

            //arrange
            var service = new ProductDataService(repository);

            //act
            var products = service.GetAllAsync();

            //assert
            Assert.IsNotNull(products);


        }
    }
}

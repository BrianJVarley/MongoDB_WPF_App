using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDBApp.DAL;
using MongoDBApp.Services;
using Tests.Mocks;

namespace Tests
{
    [TestClass]
    public class CustomerDataServiceTest
    {

        private IRepository repository;

        [TestInitialize]
        public void Init()
        {
            repository = new MockRepository();
        }


        [TestMethod]
        public void GetCustomerDetailsTest()
        {

            //arrange
            var service = new CustomerDataService(repository);

            //act
            var customer = service.GetCustomerByEmail("brian@gmail.com");

            //assert
            Assert.IsNotNull(customer);


        }
    }
}

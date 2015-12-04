using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDBApp.DAL;
using MongoDBApp.Services;
using Tests.Mocks;
using MongoDBApp.Models;

namespace Tests
{
    [TestClass]
    public class CustomerDataServiceTest
    {

        private IRepository<CustomerModel> repository;

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
            var customer = service.GetByEmailAsync("brian@gmail.com");

            //assert
            Assert.IsNotNull(customer);


        }
    }
}

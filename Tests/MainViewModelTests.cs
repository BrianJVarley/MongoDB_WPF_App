using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBApp.Services;
using MongoDBApp.ViewModels;
using Tests.Mocks;
using System.Collections.ObjectModel;
using MongoDBApp.Models;

namespace Tests
{

    [TestClass]
    public class CustomerDetailsViewModelTests
    {
        private IDataService<CustomerModel> customerDataService;
        private IDataService<Country> countryDataService;

        private CustomerDetailsViewModel GetViewModel()
        {
            return new CustomerDetailsViewModel(this.customerDataService, this.countryDataService);
        }
       

        [TestInitialize]
        public void Init()
        {
            customerDataService = new MockCustomerDataService();
        }

        [TestMethod]
        public async Task LoadAllCustomers()
        {
            //Arrange
            ObservableCollection<CustomerModel> customers = null;
            var result = await customerDataService.GetAllAsync();
            var expectedCustomers = result;

            //act
            var viewModel = GetViewModel();
            customers = viewModel.Customers;

            //assert
            CollectionAssert.AreEqual(expectedCustomers, customers);
        }



    }
}

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
    public class MainViewModelTests
    {
        private IDataService<CustomerModel> customerDataService;
        private IDataService<CountryModel> countryDataService;

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
        public void LoadAllCustomers()
        {
            //Arrange
            ObservableCollection<CustomerModel> customers = null;
            var expectedCustomers = customerDataService.GetAll();

            //act
            var viewModel = GetViewModel();
            customers = viewModel.Customers;

            //assert
            CollectionAssert.AreEqual(expectedCustomers, customers);
        }



    }
}

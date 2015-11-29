using MongoDBApp.DAL;
using MongoDBApp.Services;
using MongoDBApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.ViewModels
{
    class ViewModelLocator
    {

        private static ICustomerDataService customerDataService = new CustomerDataService(CustomerRepository.Instance);

        private static MainViewModel mainViewModel = new MainViewModel(customerDataService);



        public static MainViewModel MainViewModel
        {
            get
            {
                return mainViewModel;
            }
        }

    }
}

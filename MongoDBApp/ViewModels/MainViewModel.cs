using MongoDBApp.Common;
using MongoDBApp.Models;
using MongoDBApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.ViewModels
{

    class MainViewModel : ObservableObject, INotifyPropertyChanged
    {

        private static CustomerRepository _customerObj;

        public MainViewModel(CustomerRepository customer)
        {
            _customerObj = customer;
            this.QueryDataFromPersistence();
        }


        public static CustomerRepository CustomerObject
        {
            get { return _customerObj; }
            set
            {
                if (value == _customerObj) return;
                _customerObj = value;
            }
        }


        public void QueryDataFromPersistence()
        {
            CustomerRepository.Instance.LoadCustomers();
        }

    }
}

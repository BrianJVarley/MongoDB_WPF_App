using MongoDBApp.Common;
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



    }
}

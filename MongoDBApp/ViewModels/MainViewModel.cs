using Microsoft.Practices.Prism.Commands;
using MongoDBApp.Common;
using MongoDBApp.Models;
using MongoDBApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.ViewModels
{

    class MainViewModel : ObservableObject, INotifyPropertyChanged
    {

        private DelegateCommand objCommand;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

      

        public MainViewModel(CustomerRepository customerRepository, CustomerModel customerObj)
        {
            _customerObj = customerObj;
            _customerRepository = customerRepository;

            QueryDataFromPersistence();
        }


        private static CustomerRepository _customerRepository;
        public static CustomerRepository CustomerRepository
        {
            get { return _customerRepository; }
            set
            {
                if (_customerRepository != value)
                {
                    _customerRepository = value;
                   
                }
            }
        }


        private static CustomerModel _customerObj;
        public static CustomerModel CustomerObj
        {
            get { return _customerObj; }
            set
            {
                if (_customerObj != value)
                {
                    _customerObj = value;

                }
            }
        }



        private ObservableCollection<CustomerModel> customers;
        public ObservableCollection<CustomerModel> Customers
        {
            get
            {
                return customers;
            }
            set
            {
                customers = value;
                RaisePropertyChanged("Customers");
            }
        }



        
        public string Id
        {
            get { return Convert.ToString(_customerObj.Id); }
            set { _customerObj.Id = MongoDB.Bson.ObjectId.Parse(value); }
        }
         


        public string FirstName
        {
            get { return _customerObj.FirstName; }
            set { _customerObj.FirstName = value; }
        }


        public string LastName
        {
            get { return _customerObj.LastName; }
            set { _customerObj.LastName = value; }
        }



        public string Email
        {
            get { return _customerObj.Email; }
            set { _customerObj.Email = value; }
        }    



        private void QueryDataFromPersistence()
        {
            Customers = customerRepository.LoadCustomers().ToObservableCollection();

        }


        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}

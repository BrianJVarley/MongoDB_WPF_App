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
using MongoDBApp.Extensions;
using MongoDB.Bson;

namespace MongoDBApp.ViewModels
{

    class MainViewModel : INotifyPropertyChanged
    {

        private DelegateCommand objCommand;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private ICustomerDataService _customerDataService;




        public MainViewModel() //ICustomerDataService customerDataService
        {
            //this._customerDataService = customerDataService;
            QueryDataFromPersistence();
        }


      
       
        private CustomerModel selectedCustomer;
        public CustomerModel SelectedCustomer
        {
            get
            {
                return selectedCustomer;
            }
            set
            {
                selectedCustomer = value;
                RaisePropertyChanged("SelectedCustomer");
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


        /*
        private ObjectId _id;
        public ObjectId ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RaisePropertyChanged("ID");
            }
        }



        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }


        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }



        private string _email;
        public string Email
        {
            get
            {
                return  this._email;
               
            }
            set
            {
                this._email = value;
                RaisePropertyChanged("Email");
            }
        }
         */
      
     


        private void QueryDataFromPersistence()
        {
            Customers = new ObservableCollection<CustomerModel> { new CustomerModel() {FirstName = "myname", LastName = "myfamily"}, new CustomerModel() {FirstName = "yourname", LastName = "yourfamily"} };
                //_customerDataService.GetAllCustomers().ToObservableCollection();

        }


     
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



    }
}

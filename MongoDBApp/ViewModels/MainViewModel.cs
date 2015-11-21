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




        public MainViewModel(ICustomerDataService customerDataService) 
        {
            this._customerDataService = customerDataService;
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
     


        private void QueryDataFromPersistence()
        {
            Customers =  _customerDataService.GetAllCustomers().ToObservableCollection();
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

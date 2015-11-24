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
using System.Windows.Input;

namespace MongoDBApp.ViewModels
{

    class MainViewModel : INotifyPropertyChanged
    {

        public ICommand UpdateCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private ICustomerDataService _customerDataService;


        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }




        public MainViewModel(ICustomerDataService customerDataService) 
        {
            this._customerDataService = customerDataService;
            QueryDataFromPersistence();

            UpdateCommand = new CustomCommand((c) => UpdateCustomerAsync(c).FireAndLogErrors(), CanUpdateCustomer);
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


        private Boolean button_enabled;
        public Boolean ButtonEnabled 
        {
            get { return button_enabled; }
            set
            {
                button_enabled = value;
                RaisePropertyChanged("ButtonEnabled"); // 
            }
        }
     


        private void QueryDataFromPersistence()
        {
            Customers =  _customerDataService.GetAllCustomers().ToObservableCollection();
        }


        private bool CanUpdateCustomer(object obj)
        {
            return true;
        }


        private async Task UpdateCustomerAsync(object customer) { 
            
            ButtonEnabled = true;
            await Task.Run(() => _customerDataService.UpdateCustomer(selectedCustomer));
            ButtonEnabled = false; 
        }
        


    }
}

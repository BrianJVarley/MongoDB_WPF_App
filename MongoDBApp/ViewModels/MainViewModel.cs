﻿using Microsoft.Practices.Prism.Commands;
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
        public ICommand CreateCommand { get; set; }
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

            UpdateCommand = new CustomCommand((c) => UpdateCustomerAsync(c).FireAndLogErrors(), CanModifyCustomer);
            DeleteCommand = new CustomCommand((c) => DeleteCustomerAsync(c).FireAndLogErrors(), CanModifyCustomer);
            CreateCommand = new CustomCommand((c) => AddCustomerAsync(c).FireAndLogErrors(), CanModifyCustomer);

      
            //foreach (var customerModel in Customers)
              //  MainViewModels.Add(new MainViewModel(_customerDataService));
           

        }


      #region Properties
       
        private MainViewModel selectedModel;
        public MainViewModel SelectedModel
        {
            get
            {
                return selectedModel;
            }
            set
            {
                selectedModel = value;
                RaisePropertyChanged("SelectedModel");
            }
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

        private ObservableCollection<MainViewModel> mainViewModels;
        public ObservableCollection<MainViewModel> MainViewModels
        {
            get
            {
                return mainViewModels;
            }
            set
            {
                mainViewModels = value;
                RaisePropertyChanged("MainViewModels");
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
                RaisePropertyChanged("ButtonEnabled");  
            }
        }



        private ObjectId _id;
        public ObjectId ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
                RaisePropertyChanged("ID");
            }
        }
        
        
        private string firstName;
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
                RaisePropertyChanged("LastName");
            }
        }



        private string email;
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
                RaisePropertyChanged("Email");
            }
        }
        

      #endregion


        private bool CanModifyCustomer(object obj)
        {
            return true;
        }

        #region persistence methods

        private void QueryDataFromPersistence()
        {
            Customers =  _customerDataService.GetAllCustomers().ToObservableCollection();
        }

        private async Task UpdateCustomerAsync(object customer) { 
            
            ButtonEnabled = true;
            await Task.Run(() => _customerDataService.UpdateCustomer(selectedCustomer));
            ButtonEnabled = false; 
        }


        private async Task DeleteCustomerAsync(object customer)
        {
            ButtonEnabled = true;
            await Task.Run(() => _customerDataService.DeleteCustomer(selectedCustomer));
            ButtonEnabled = false;
        }

        private async Task AddCustomerAsync(object customer)
        {
            ButtonEnabled = true;
            await Task.Run(() => _customerDataService.AddCustomer(new CustomerModel()));
            ButtonEnabled = false;
        }

        #endregion


    }
}

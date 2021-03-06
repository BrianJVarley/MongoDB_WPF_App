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
using MongoDBApp.Utility;
using PropertyChanged;
using MongoDBApp.Messages;

namespace MongoDBApp.ViewModels
{

    [ImplementPropertyChanged]
    public class CustomerDetailsViewModel : IPageViewModel, IAsyncInitialization
    {

        public ICommand UpdateCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand RefreshCommand { get; set; }


        private IDataService<CustomerModel> _customerDataService;
        private IDataService<Country> _countryDataService;

        private const string NullObjectId = "000000000000000000000000";



        public CustomerDetailsViewModel(IDataService<CustomerModel> customerDataService, IDataService<Country> countryDataService) 
        {
            this._customerDataService = customerDataService;
            this._countryDataService = countryDataService;

            Initialization = GetAllCustomersAsync();

            IsEnabled = true;
            LoadCommands();

            
        
        }


        
       


      #region Properties
       
        
        public CustomerModel SelectedCustomer  { get; set; }

        public bool IsEnabled { get; set; }
        
        public ObservableCollection<CustomerModel> Customers { get; set; }

        public ObservableCollection<Country> Countries { get; set; }
    
        public Boolean ButtonEnabled { get; set; }

        public string AuthenticatedUserName { get; set; }

        public Task Initialization { get; private set; }
       

     
        public string Name
        {
            get
            {
                return "Customer Details";
            }
        }
      

      #endregion


        #region methods


        private void LoadCommands()
        {
            UpdateCommand = new CustomCommand((c) => UpdateCustomerAsync(c).FireAndLogErrors(), CanModifyCustomer);
            DeleteCommand = new CustomCommand((c) => DeleteCustomerAsync(c).FireAndLogErrors(), CanModifyCustomer);
            SaveCommand = new CustomCommand((c) => SaveCustomerAsync(c).FireAndLogErrors(), CanSaveCustomer);
            AddCommand = new RelayCommand(AddCustomerLocal);
        }


        

        private bool CanModifyCustomer(object obj)
        {
           
            if (SelectedCustomer != null && SelectedCustomer.FirstName != null && SelectedCustomer.Country != null &&
                SelectedCustomer.LastName != null && SelectedCustomer.Email != null
                && SelectedCustomer.Address != null && SelectedCustomer.Id.ToString() != NullObjectId)            
            {
                return true;
            }

            return false;            
        }


        private bool CanSaveCustomer(object obj)
        {

            if (SelectedCustomer != null && SelectedCustomer.FirstName != null && SelectedCustomer.Country != null &&
                SelectedCustomer.LastName != null && SelectedCustomer.Email != null 
                && SelectedCustomer.Address != null && SelectedCustomer.Id.ToString() == NullObjectId)
            {
                return true;
            }

            return false;
        }


        public void OnSelectedCustomerChanged()
        { 
            Messenger.Default.Send<CustomerModel>(SelectedCustomer);
            Messenger.Default.Send<ObservableCollection<CustomerModel>>(Customers);
        }

      
       
        private async Task GetAllCustomersAsync()
        {
            var customerResult = await _customerDataService.GetAllAsync();
            Customers = customerResult.ToObservableCollection();

            var countryResult = await _countryDataService.GetAllAsync();
            Countries = countryResult.ToObservableCollection();
        }

       
        private async Task UpdateCustomerAsync(object customer) { 
            
            ButtonEnabled = true;
            await Task.Run(() => _customerDataService.UpdateAsync(SelectedCustomer));
            ButtonEnabled = false;
            await GetAllCustomersAsync();
        }


        private async Task DeleteCustomerAsync(object customer)
        {
            ButtonEnabled = true;
            await Task.Run(() => _customerDataService.DeleteAsync(SelectedCustomer));
            ButtonEnabled = false;
            await GetAllCustomersAsync();
        }

       
        private async Task SaveCustomerAsync(object customer)
        {    
           if(Customers.Any(str => String.Compare(str.Email, SelectedCustomer.Email, true) == -1))
           {
                ButtonEnabled = true;
                await Task.Run(() => _customerDataService.AddAsync(SelectedCustomer));
                ButtonEnabled = false;
                await GetAllCustomersAsync();                
            }
          
                return;            
        }


        private void AddCustomerLocal(object customer)
        {
                ButtonEnabled = true;
                //create new customer and add to data grid, set as selected customer
                CustomerModel newCustomer = new CustomerModel();
                Customers.Add(newCustomer);
                SelectedCustomer = newCustomer;
                ButtonEnabled = false;            
        }

        #endregion


       
    }
}

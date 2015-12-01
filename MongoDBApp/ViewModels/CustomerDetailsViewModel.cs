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

    public class CustomerDetailsViewModel : INotifyPropertyChanged, IPageViewModel
    {

        public ICommand UpdateCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand RefreshCommand { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;
        private ICustomerDataService _customerDataService;


        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }




        public CustomerDetailsViewModel(ICustomerDataService customerDataService) 
        {
            this._customerDataService = customerDataService;
            QueryDataFromPersistence();

            UpdateCommand = new CustomCommand((c) => UpdateCustomerAsync(c).FireAndLogErrors(), CanModifyCustomer);
            DeleteCommand = new CustomCommand((c) => DeleteCustomerAsync(c).FireAndLogErrors(), CanModifyCustomer);
            SaveCommand = new CustomCommand((c) => SaveCustomerAsync(c).FireAndLogErrors(), CanModifyCustomer);
            AddCommand = new RelayCommand(AddCustomer);
            //RefreshCommand = new RelayCommand(QueryDataFromPersistence());

        }


      #region Properties
       
        
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
                RaisePropertyChanged("ButtonEnabled");  
            }
        }

      
        
        

      #endregion


        private bool CanModifyCustomer(object obj)
        {
            
            if (SelectedCustomer != null && SelectedCustomer.FirstName != null && 
                SelectedCustomer.LastName != null && SelectedCustomer.Email != null && SelectedCustomer.Address != null)            
            {
                return true;
            }

            return false;            
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
            QueryDataFromPersistence();
        }


        private async Task DeleteCustomerAsync(object customer)
        {
            ButtonEnabled = true;
            await Task.Run(() => _customerDataService.DeleteCustomer(selectedCustomer));
            ButtonEnabled = false;
            QueryDataFromPersistence();
        }

       
        private async Task SaveCustomerAsync(object customer)
        {

     
           if(!Customers.Any(str => String.Compare(str.Email, SelectedCustomer.Email, true) == -1))
           {
                ButtonEnabled = true;
                await Task.Run(() => _customerDataService.AddCustomer(selectedCustomer));
                ButtonEnabled = false;
                QueryDataFromPersistence();
                
            }
          
                return;            
        }


        private void AddCustomer(object customer)
        {
            
                ButtonEnabled = true;
                //create new customer and add, set as selected customer
                CustomerModel newCustomer = new CustomerModel();
                Customers.Add(newCustomer);
                SelectedCustomer = newCustomer;
                ButtonEnabled = false;
            
        }

        #endregion


        public string Name
        {
            get
            {
                return "Customer Details";
            }
        }


    }
}

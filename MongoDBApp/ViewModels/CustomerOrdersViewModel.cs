using MongoDBApp.Models;
using MongoDBApp.Services;
using MongoDBApp.Utility;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBApp.Extensions;
using System.Windows.Input;
using MongoDBApp.Common;
using MongoDBApp.Messages;

namespace MongoDBApp.ViewModels
{
    [ImplementPropertyChanged]
    public class CustomerOrdersViewModel : IPageViewModel
    {


        private IDataService<OrderModel> _orderDataService;
        public ICommand SaveCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand WindowLoadedCommand { get; set; }
        private IDialogService _dialogService;

        public CustomerOrdersViewModel(IDataService<OrderModel> orderDataService, IDialogService dialogservice)
        {

                      
            this._orderDataService = orderDataService;
            this._dialogService = dialogservice;

            Messenger.Default.Register<CustomerModel>(this, OnUpdateOrderMessageReceived);                  
            LoadCommands();


           
        }

       
        
        

        #region properties

        public string SelectedCustomerEmail { get; set; }

        public ObservableCollection<OrderModel> CustomerOrders { get; set; }

        public OrderModel SelectedOrder { get; set; }

        public ProductModel SelectedProduct { get; set; }

        public Task Initialization { get; set; }

        public bool IsEnabled { get; set; }
        
        public string Name
        {
            get
            {
                return "Order Details";
            }
        }

       
        #endregion



        #region methods

       
        private void OnUpdateProductMessageReceived(ProductModel product)
        {
            SelectedProduct = product;           
        }

        private void LoadCommands()
        {
            SaveCommand = new CustomCommand((c) => SaveCustomerAsync(c).FireAndLogErrors(), CanSaveOrder);
            EditCommand = new CustomCommand(EditOrder, CanModifyOrder);
            WindowLoadedCommand = new CustomCommand(WindowLoaded, CanLoadWindow);
        }


        private bool CanSaveOrder(object obj)
        {
            if (SelectedOrder != null && SelectedOrder.Email != null && SelectedOrder.Date != null &&
                SelectedOrder.Id != null)
            {
                return true;
            }

            return false;
        }


        private bool CanModifyOrder(object obj)
        {

            if (SelectedOrder != null && SelectedOrder.Email != null && SelectedOrder.Date != null &&
                SelectedOrder.Id != null && SelectedProduct != null )
            {
                return true;
            }

            return false;
        }


    

        private void EditOrder(object obj)
        {
            ProductViewModel pvm = new ProductViewModel(_dialogService);
            pvm.Present(pvm);
            Messenger.Default.Send<ProductModel>(SelectedProduct);                              
        }


        private bool CanLoadWindow(object obj)
        {
            return true;
        }

        private void WindowLoaded(object obj)
        {
            
        }


        private void OnUpdateOrderMessageReceived(CustomerModel customer)
        {
            SelectedCustomerEmail = customer.Email;
            LoadCustomerOrdersAsync(SelectedCustomerEmail);
            IsEnabled = true;
          
        }



        //private async Task InitializeAsync()
        //{
        //    var customer = await AwaitableMessages.NextMessageAsync<CustomerModel>(); 
        //    SelectedCustomerEmail = customer.Email;
        //    await LoadCustomerOrdersAsync(SelectedCustomerEmail);
        //    IsEnabled = true;
        //}


       

        public async Task LoadCustomerOrdersAsync(string email)
        {
            var ordersResult = await _orderDataService.GetAllByEmailAsync(email);
            CustomerOrders = ordersResult.ToObservableCollection();
        }


       

        private async Task SaveCustomerAsync(object customer)
        {

            if (SelectedOrder != null)
            {
                IsEnabled = true;
                await Task.Run(() => _orderDataService.UpdateAsync(SelectedOrder));
                IsEnabled = false;
            }

            return;
        }


        #endregion

       


    }
}

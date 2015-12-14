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

namespace MongoDBApp.ViewModels
{
    [ImplementPropertyChanged]
    public class CustomerOrdersViewModel : IPageViewModel
    {


        private IDataService<OrderModel> _orderDataService;
        public ICommand SaveCommand { get; set; }


        public CustomerOrdersViewModel(IDataService<OrderModel> orderDataService)
        {

            this._orderDataService = orderDataService;
            Messenger.Default.Register<CustomerModel>(this, OnSelectedCustomerReceived);
            LoadCommands();
            
        }


        private void LoadCommands()
        {            
            SaveCommand = new CustomCommand((c) => SaveCustomerAsync(c).FireAndLogErrors(), CanSaveOrder);           
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
                SelectedOrder.Id != null)
            {
                return true;
            }

            return false;
        }


        public void OnSelectedCustomerReceived(CustomerModel customer)
        {
            SelectedCustomerEmail = customer.Email;
            LoadCustomerOrdersAsync(SelectedCustomerEmail);
            IsEnabled = true;
        }


        #region properties

        public string SelectedCustomerEmail { get; set; }

        public ObservableCollection<OrderModel> CustomerOrders { get; set; }

        public OrderModel SelectedOrder { get; set; }
 

        public string Name
        {
            get
            {
                return "Order Details";
            }
        }

        public bool IsEnabled { get; set; }

        #endregion



        #region persistence methods


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

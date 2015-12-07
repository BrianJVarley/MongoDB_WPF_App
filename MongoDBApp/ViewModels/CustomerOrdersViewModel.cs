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

namespace MongoDBApp.ViewModels
{
    [ImplementPropertyChanged]
    public class CustomerOrdersViewModel : IPageViewModel
    {


        private IDataService<OrderModel> _orderDataService;


        public CustomerOrdersViewModel(IDataService<OrderModel> orderDataService)
        {

            this._orderDataService = orderDataService;
            Messenger.Default.Register<CustomerModel>(this, OnSelectedCustomerReceived);
            
        }


        public void OnSelectedCustomerReceived(CustomerModel customer)
        {
            SelectedCustomerEmail = customer.Email;
            LoadCustomerOrders(SelectedCustomerEmail);
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


        public async Task LoadCustomerOrders(string email)
        {
            var ordersResult = await _orderDataService.GetAllByEmailAsync(email);
            CustomerOrders = ordersResult.ToObservableCollection();
        }


        #endregion

    }
}

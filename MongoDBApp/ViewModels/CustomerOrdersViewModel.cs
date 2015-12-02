using MongoDBApp.Models;
using MongoDBApp.Utility;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.ViewModels
{
    [ImplementPropertyChanged]
    public class CustomerOrdersViewModel : IPageViewModel
    {
       


        public CustomerOrdersViewModel()
        {

            Messenger.Default.Register<CustomerModel>(this, OnCustomerReceived);
        }


        public void OnCustomerReceived(CustomerModel customer)
        {
            SelectedCustomer = customer;
            IsEnabled = true;
        }



        public CustomerModel SelectedCustomer { get; set; }
        

        public string Name
        {
            get
            {
                return "Order Details";
            }
        }

        public bool IsEnabled { get; set; }
       
    }
}

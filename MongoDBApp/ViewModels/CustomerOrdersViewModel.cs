using MongoDBApp.Models;
using MongoDBApp.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.ViewModels
{
    public class CustomerOrdersViewModel : INotifyPropertyChanged, IPageViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        public CustomerOrdersViewModel()
        {


            Messenger.Default.Register<CustomerModel>(this, OnCustomerReceived);


        }


        public void OnCustomerReceived(CustomerModel customer)
        {
            SelectedCustomer = customer;
            IsEnabled = true;
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




        public string Name
        {
            get
            {
                return "Order Details";
            }
        }


        private Boolean is_enabled;
        public bool IsEnabled
        {
            get { return is_enabled; }
            set
            {
                is_enabled = value;
                RaisePropertyChanged("IsEnabled");
            }
        }
    }
}

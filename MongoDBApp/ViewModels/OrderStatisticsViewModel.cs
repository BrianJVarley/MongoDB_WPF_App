using MongoDBApp.Models;
using MongoDBApp.Utility;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.ViewModels
{

    [ImplementPropertyChanged]
    class OrderStatisticsViewModel : IPageViewModel
    {



        public OrderStatisticsViewModel()
        {
            Messenger.Default.Register<ObservableCollection<CustomerModel>>(this, OnCustomersReceived);         
        }


        public void OnCustomersReceived(ObservableCollection<CustomerModel> customers)
        {
            Customers = customers;
            IsEnabled = true;

            PieCollection = new ObservableCollection<PiePoint>();
            PieCollection.Add(new PiePoint { Name = "Mango", Share = 10 });
            PieCollection.Add(new PiePoint { Name = "Banana", Share = 36 });
        }


        public class PiePoint
        {
            public string Name { get; set; }
            public Int16 Share { get; set; }
        }


        public ObservableCollection<PiePoint> PieCollection { get; set; }

        public ObservableCollection<CustomerModel> Customers { get; set; }



        public string Name
        {
            get
            {
                return "Order Statistics";
            }
        }

        public bool IsEnabled { get; set; }  
    
            
    }
}

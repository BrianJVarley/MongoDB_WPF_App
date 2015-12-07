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

           

            IEnumerable<PiePointModel> piePoints = Customers.GroupBy(i => i.Country).Select(s => new PiePointModel()
            { 
                Name = s.Key, 
                Amount = s.Count() 
            });
            CountryRatioCollection = new ObservableCollection<PiePointModel>(piePoints);
        }


   
        public ObservableCollection<PiePointModel> CountryRatioCollection { get; set; }

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

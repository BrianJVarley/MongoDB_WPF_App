using PropertyChanged;
using System;
using System.Collections.Generic;
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

        }


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

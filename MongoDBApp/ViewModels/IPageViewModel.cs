using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.ViewModels
{
    public interface IPageViewModel
    {

        string Name { get; }
        Boolean IsEnabled { get; set; }

    }
}

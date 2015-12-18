using MongoDBApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Services
{
    public interface IDialogService
    {
        void CloseDialog();
        void ShowDialog(ProductViewModel prodVM);
        
    }
}

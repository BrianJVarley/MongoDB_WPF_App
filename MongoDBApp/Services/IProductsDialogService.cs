using MongoDBApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Services
{
    public interface IProductsDialogService
    {
        void CloseDialog();
        void ShowDialog(ProductsViewModel prodVM);  
    }
}

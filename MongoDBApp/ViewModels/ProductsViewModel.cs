using MongoDBApp.Common;
using MongoDBApp.Models;
using MongoDBApp.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MongoDBApp.ViewModels
{

    
    [ImplementPropertyChanged]
    public class ProductsViewModel
    {

        private IDialogService _dialogService;
        public ICommand SaveCommand { get; set; }
    

        public ProductsViewModel (IDialogService dialogService)
	    {
                this._dialogService = dialogService;

                SaveCommand = new CustomCommand(SaveProduct, CanSaveProduct);
        }



        #region properties


        public bool IsEnabled { get; set; }
        public ProductModel SelectedProduct { get; set; }



        #endregion




        #region methods

        private bool CanSaveProduct(object product)
        {
            if (SelectedProduct != null && SelectedProduct.Description != null && SelectedProduct.Quantity != null)
            {
                return true;
            }

            return false;
        }

        private void SaveProduct(object product)
        {
            _dialogService.CloseDialog();
        }


        public void Present(ProductsViewModel prodVM)
        {
            _dialogService.ShowDialog(prodVM);
        }


        #endregion

    }
}

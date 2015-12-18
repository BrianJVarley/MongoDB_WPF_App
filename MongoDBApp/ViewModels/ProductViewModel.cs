using MongoDBApp.Common;
using MongoDBApp.Messages;
using MongoDBApp.Models;
using MongoDBApp.Services;
using MongoDBApp.Utility;
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
    public class ProductViewModel 
    {

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        private IDialogService _dialogService;


        public ProductViewModel(IDialogService dialogService)
        {


            this._dialogService = dialogService;

            Messenger.Default.Register<ProductModel>(this, OnSelectedProductReceived);
           
           
            SaveCommand = new CustomCommand(SaveProduct, CanSaveProduct);
            DeleteCommand = new CustomCommand(DeleteProduct, CanDeleteProduct);

          
        }



        #region properties

        
        public bool IsEnabled { get; set; }
        public ProductModel SelectedProduct { get; set; }
 

        #endregion



        #region methods

        
        public void OnSelectedProductReceived(ProductModel product)
        {
            SelectedProduct = product;
            
        }

        private bool CanDeleteProduct(object product)
        {
            return true;
        }

        private void DeleteProduct(object product)
        {
            SelectedProduct.ProductId = " ";
            SelectedProduct.Price = 0.00f;
            SelectedProduct.Quantity = 0;
            SelectedProduct.Description = "";

            _dialogService.CloseDialog();
            Messenger.Default.Send<ProductModel>(SelectedProduct);
        }

        private bool CanSaveProduct(object product)
        {
            if (SelectedProduct != null && SelectedProduct.Description != null && SelectedProduct.ProductId != null)
            {
                return true;
            }

            return false;
        }

        private void SaveProduct(object product)
        {
            _dialogService.CloseDialog();
            Messenger.Default.Send<ProductModel>(SelectedProduct);
        }

        public void Present(ProductViewModel prodVM) 
        {
            _dialogService.ShowDialog(prodVM);
        }

       


        #endregion


    }
}

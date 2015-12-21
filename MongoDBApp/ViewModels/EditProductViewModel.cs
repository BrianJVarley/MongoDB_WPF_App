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
    public class EditProductViewModel 
    {

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        private IEditProductDialogService _dialogService;


        public EditProductViewModel(IEditProductDialogService dialogService)
        {


            this._dialogService = dialogService;

            Messenger.Default.Register<ProductModel>(this, OnSelectedProductReceived);
           
           
            SaveCommand = new CustomCommand(SaveProduct, CanSaveProduct);
            DeleteCommand = new CustomCommand(DeleteProduct, CanDeleteProduct);

          
        }



        #region properties

        
        public bool IsEnabled { get; set; }
        public ProductModel SelectedProduct { get; set; }
        public ProductModel SelectedProductTemp { get; set; }
 

        #endregion



        #region methods

        
        public void OnSelectedProductReceived(ProductModel product)
        {
            SelectedProductTemp = product;
            
        }

        private bool CanDeleteProduct(object product)
        {
            return true;
        }

        private void DeleteProduct(object product)
        {
            SelectedProduct = SelectedProductTemp;
            SelectedProduct = null;
            
            _dialogService.CloseDialog();

            Messenger.Default.Send<ProductModel>(SelectedProduct);
        }

        private bool CanSaveProduct(object product)
        {
            if (SelectedProductTemp != null && SelectedProductTemp.Description != null && SelectedProductTemp.ProductId != null)
            {
                return true;
            }

            return false;
        }

        private void SaveProduct(object product)
        {
            SelectedProduct = SelectedProductTemp;
            _dialogService.CloseDialog();
        }

        public void Present(EditProductViewModel prodVM) 
        {
            _dialogService.ShowDialog(prodVM);
        }

       


        #endregion


    }
}

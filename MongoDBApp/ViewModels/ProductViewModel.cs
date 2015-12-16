using MongoDBApp.Common;
using MongoDBApp.Messages;
using MongoDBApp.Models;
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
    class ProductViewModel 
    {

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        public ProductViewModel()
        {

           
            SaveCommand = new CustomCommand(SaveProduct, CanSaveProduct);
            DeleteCommand = new CustomCommand(DeleteProduct, CanDeleteProduct);

            Messenger.Default.Register<ProductModel>(this, OnSelectedProductReceived);

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
            Messenger.Default.Send<UpdateProductMessage>(new UpdateProductMessage());
        }

        private bool CanSaveProduct(object product)
        {
            return true;
        }

        private void SaveProduct(object product)
        {
            Messenger.Default.Send<UpdateProductMessage>(new UpdateProductMessage());
        }


        #endregion


    }
}

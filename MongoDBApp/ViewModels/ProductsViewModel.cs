using MongoDBApp.Common;
using MongoDBApp.Models;
using MongoDBApp.Services;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MongoDBApp.Extensions;
using MongoDBApp.Utility;

namespace MongoDBApp.ViewModels
{

    
    [ImplementPropertyChanged]
    public class ProductsViewModel
    {

        private IProductsDialogService _dialogService;
        public ICommand AddCommand { get; set; }
        public ICommand WindowLoadedCommand { get; set; }
        private IDataService<ProductModel> _productDataService;
        


        public ProductsViewModel(IProductsDialogService dialogService, IDataService<ProductModel> productDataService)
	    {
            this._productDataService = productDataService;
            this._dialogService = dialogService;
            
            LoadCommands();
                             
        }



        #region properties


        public bool IsEnabled { get; set; }
        public ProductModel SelectedProduct { get; set; }
        public ObservableCollection<ProductModel> Products { get; set; }
        public Task Initialization { get; private set; }



        #endregion




        #region methods


        //public void OnSelectedProductChanged()
        //{
        //    Messenger.Default.Send<ProductModel>(SelectedProduct);
        //}



        private async Task GetAllProductsAsync()
        {
            var productsResult = await _productDataService.GetAllAsync();
            Products = productsResult.ToObservableCollection();
           
        }


        private void LoadCommands()
        {
            AddCommand = new CustomCommand(AddProduct, CanAddProduct);
            WindowLoadedCommand = new CustomCommand((c) => WindowLoadedAsync(c).FireAndLogErrors(), CanLoadWindow);
        }

        private bool CanAddProduct(object product)
        {
            if (SelectedProduct != null && SelectedProduct.Description != null && SelectedProduct.Quantity != null)
            {
                return true;
            }

            return false;
        }

        private void AddProduct(object product)
        {
            _dialogService.CloseDialog();
        }


        public void Present(ProductsViewModel prodVM)
        {
            _dialogService.ShowDialog(prodVM);
        }

        private async Task WindowLoadedAsync(object obj)
        {
            await GetAllProductsAsync();
            IsEnabled = true;
        }


        private bool CanLoadWindow(object obj)
        {
            return true;
        }


        #endregion

    }
}

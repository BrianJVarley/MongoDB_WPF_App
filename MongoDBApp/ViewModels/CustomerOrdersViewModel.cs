using MongoDBApp.Models;
using MongoDBApp.Services;
using MongoDBApp.Utility;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBApp.Extensions;
using System.Windows.Input;
using MongoDBApp.Common;
using MongoDBApp.Messages;

namespace MongoDBApp.ViewModels
{
    [ImplementPropertyChanged]
    public class CustomerOrdersViewModel : IPageViewModel
    {


        private IDataService<OrderModel> _orderDataService;
        public ICommand SaveCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand WindowLoadedCommand { get; set; }
        private IEditProductDialogService _editProductsDialogService;
        private IProductsDialogService _productsDialogService;
        private IDataService<ProductModel> _productDataService;
        private const string NullObjectId = "000000000000000000000000";
        

        public CustomerOrdersViewModel(IDataService<OrderModel> orderDataService, IEditProductDialogService editProductDialogservice, IProductsDialogService productsDialogservice, IDataService<ProductModel> productDataService)
        {                  
            this._orderDataService = orderDataService;
            this._productDataService = productDataService;
            this._editProductsDialogService = editProductDialogservice;
            this._productsDialogService = productsDialogservice;

            Messenger.Default.Register<CustomerModel>(this, OnUpdateOrderMessageReceived);
            LoadCommands();


        }

       
        
        

        #region properties

        public string SelectedCustomerEmail { get; set; }

        public ObservableCollection<OrderModel> CustomerOrders { get; set; }

        public OrderModel SelectedOrder { get; set; }

        public ProductModel SelectedProduct { get; set; }

        public Task Initialization { get; set; }

        public bool IsEnabled { get; set; }

        public bool ButtonEnabled { get; set; }
        
        public string Name
        {
            get
            {
                return "Order Details";
            }
        }

       
        #endregion



        #region methods

              

        private void LoadCommands()
        {
            SaveCommand = new CustomCommand((c) => SaveCustomerAsync(c).FireAndLogErrors(), CanSaveOrder);
            EditCommand = new CustomCommand(EditOrder, CanModifyOrder);
            AddCommand = new CustomCommand(AddProduct, CanAddproduct);
            WindowLoadedCommand = new CustomCommand((c) => WindowLoadedAsync(c).FireAndLogErrors(), CanLoadWindow);
            NewCommand = new RelayCommand(AddNewOrderLocal);


        }


        private bool CanSaveOrder(object obj)
        {
            if (SelectedOrder != null && SelectedOrder.Email != null && SelectedOrder.Date != null &&
                SelectedOrder.Id != null)
            {
                return true;
            }

            return false;
        }


        private bool CanModifyOrder(object obj)
        {

            if (SelectedOrder != null && SelectedOrder.Email != null && SelectedOrder.Date != null &&
                SelectedOrder.Id != null && SelectedProduct != null )
            {
                return true;
            }

            return false;
        }


        private void EditOrder(object obj)
        {
            EditProductViewModel epvm = new EditProductViewModel(_editProductsDialogService);
            epvm.Present(epvm);
            Messenger.Default.Send<ProductModel>(SelectedProduct);                              
        }



        private bool CanAddproduct(object obj)
        {
            return true;
           
        }


        private void AddProduct(object obj)
        {
            ProductsViewModel pvm = new ProductsViewModel(_productsDialogService, _productDataService);
            pvm.Present(pvm);            
        }


        private async Task WindowLoadedAsync(object obj)
        {
            await LoadCustomerOrdersAsync(SelectedCustomerEmail);
            IsEnabled = true;
        }


        private bool CanLoadWindow(object obj)
        {
            return true;
        }
     
        private void OnUpdateOrderMessageReceived(CustomerModel customer)
        {
            SelectedCustomerEmail = customer.Email;
            IsEnabled = true;    
        }

        private void OnUpdateProductMessageReceived(ProductModel product)
        {
            SelectedOrder.Products.Add(product);
        }

     
        public async Task LoadCustomerOrdersAsync(string email)
        {
            var ordersResult = await _orderDataService.GetAllByEmailAsync(email);
            CustomerOrders = ordersResult.ToObservableCollection();
        }

     
        private async Task SaveCustomerAsync(object customer)
        {

            if (SelectedOrder != null)
            {
                ButtonEnabled = true;
                if(SelectedOrder.Id.ToString() == NullObjectId)
                {
                    await Task.Run(() => _orderDataService.AddAsync(SelectedOrder));
                    ButtonEnabled = false;
                }
                else
                await Task.Run(() => _orderDataService.UpdateAsync(SelectedOrder));
                ButtonEnabled = false;
            }

            return;
        }


        private bool CanAddOrder(object obj)
        {
            return true;

        }

        private void AddNewOrderLocal(object order)
        {
            //create new customer and add to data grid, set as selected order
            OrderModel newOrder = new OrderModel();
            CustomerOrders.Add(newOrder);
            newOrder.Email = SelectedCustomerEmail;
            newOrder.Date = DateTime.Now;
            SelectedOrder = newOrder;
        }


        #endregion    

    }
}

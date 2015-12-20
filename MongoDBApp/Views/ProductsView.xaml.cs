using MongoDBApp.Services;
using MongoDBApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MongoDBApp.Views
{
    /// <summary>
    /// Interaction logic for ProductsView.xaml
    /// </summary>
    public partial class ProductsView : Window, IDialogService
    {
        public ProductsView()
        {
            InitializeComponent();
            this.DataContext = new ProductsViewModel(this);
        }

        public void CloseDialog()
        {
            if (this != null)
                this.Visibility = Visibility.Collapsed;
        }

        public void ShowDialog(ViewModels.EditProductViewModel editProdVM)
        {
            throw new NotImplementedException();
        }

        public void ShowDialog(ViewModels.ProductsViewModel prodVM)
        {
            this.DataContext = prodVM;
            this.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}

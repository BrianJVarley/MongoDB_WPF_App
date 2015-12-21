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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MongoDBApp.Views
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class EditProductView : Window, IDialogService
    {
       
        public EditProductView()
        {
            InitializeComponent();
            this.DataContext = new EditProductViewModel(this);
           
        }

        public void CloseDialog()
        {
            if (this != null)
                this.Visibility = Visibility.Collapsed;
        }

        public void ShowDialog(EditProductViewModel editProdVM)
        {
            this.DataContext = editProdVM;
            this.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }


        public void ShowDialog(ProductsViewModel prodVM)
        {
            throw new NotImplementedException();
        }

    }
}

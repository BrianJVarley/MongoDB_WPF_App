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
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MongoDBApp
{
    using MongoDB.Bson;
    using MongoDB.Driver;
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public MainWindow()
        {
            InitializeComponent();

            _client = new MongoClient();
            _database = _client.GetDatabase("local");


        }
    }
}

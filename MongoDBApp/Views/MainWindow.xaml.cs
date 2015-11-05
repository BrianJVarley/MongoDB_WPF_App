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
using MongoDB.Driver;
using MongoDB.Shared;

namespace MongoDBApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString = "mongodb://<brianVarley>:<Starlight123;>@ds048878.mongolab.com:48878/orders";
        
        public MainWindow()
        {
            InitializeComponent();

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("orders");

            //Get a handle on the customers collection:
            var collection = database.GetCollection<BsonDocument>("customers");
            //var documents = await collection.Find(new BsonDocument()).ToListAsync();


        }
    }
}

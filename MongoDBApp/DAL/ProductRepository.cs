using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MongoDBApp.DAL
{
    class ProductRepository : IRepository<ProductModel>
    {


        private static string connectionString = Properties.Settings.Default.ordersConnectionString;
        private static readonly ProductRepository instance = new ProductRepository();
        private static List<ProductModel> productList = new List<ProductModel>();


        static ProductRepository()
        {
        }

        private ProductRepository()
        {

        }

        public static ProductRepository Instance
        {
            get
            {
                return instance;
            }
        }


        public Task<ProductModel> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> GetAllByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetByIdAsync(MongoDB.Bson.ObjectId id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductModel>> GetAllAsync()
        {
            if (productList.Count == 0)
                await LoadDbAsync();
            return productList;
        }

        public async Task UpdateAsync(ProductModel t)
        {
            var collection = StartConnection();
            var filter = Builders<ProductModel>.Filter.Where(x => x.ProductId == t.ProductId);

            collection.Find(filter).ToString();
            var result = await collection.ReplaceOneAsync(filter, t, new UpdateOptions { IsUpsert = true });
        }

        public Task AddAsync(ProductModel t)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ProductModel t)
        {
            throw new NotImplementedException();
        }

        public async Task LoadDbAsync()
        {
            var productCollection = StartConnection();

            try
            {
                productList = await productCollection.Find(new BsonDocument()).ToListAsync();

            }
            catch (MongoException ex)
            {
                //Log exception here:
                MessageBox.Show("A connection error occurred: " + ex.Message, "Connection Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        public IMongoCollection<ProductModel> StartConnection()
        {

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("orders");
            //Get a handle on the products collection:
            var collection = database.GetCollection<ProductModel>("products");
            return collection;
        }
    }
}

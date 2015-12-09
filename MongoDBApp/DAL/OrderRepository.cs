using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MongoDBApp.Extensions;

namespace MongoDBApp.DAL
{
    class OrderRepository : IRepository<OrderModel>
    {


         //Database connection string
        private static string connectionString = Properties.Settings.Default.ordersConnectionString;
        private static readonly OrderRepository instance = new OrderRepository();
        private static List<OrderModel> orderList = new List<OrderModel>();


        static OrderRepository()
        {
        }

        private OrderRepository()
        {

        }

        public static OrderRepository Instance
        {
            get
            {
                return instance;
            }
        }




        public async Task<OrderModel> GetByEmailAsync(string email)
        {
            if (orderList == null)
                await LoadDbAsync();
            return orderList.Where(c => c.Email == email).FirstOrDefault();
        }


        public async Task<List<OrderModel>> GetAllByEmailAsync(string email)
        {
            if (orderList == null || orderList.Count() == 0)
                await LoadDbAsync();
            return orderList.Where(c => c.Email.Equals(email)).ToList();           
        }

        public async Task<OrderModel> GetByIdAsync(MongoDB.Bson.ObjectId id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(OrderModel t)
        {
            var collection = StartConnection();
            var filter = Builders<OrderModel>.Filter.Where(x => x.Id == t.Id);

            collection.Find(filter).ToString();
            var result = await collection.ReplaceOneAsync(filter, t, new UpdateOptions { IsUpsert = true });

            var index = orderList.FindIndex(a => a.Id == t.Id);
            orderList[index] = t;
        }

        public async Task AddAsync(OrderModel t)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(OrderModel t)
        {
            throw new NotImplementedException();
        }

        public async Task LoadDbAsync()
        {
            var orderCollection = StartConnection();

            try
            {
                orderList = await orderCollection.Find(new BsonDocument()).ToListAsync();

            }
            catch (MongoException ex)
            {
                //Log exception here:
                MessageBox.Show("A connection error occurred: " + ex.Message, "Connection Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        public IMongoCollection<OrderModel> StartConnection()
        {

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("orders");
            //Get a handle on the customer_orders collection:
            var collection = database.GetCollection<OrderModel>("customerOrders");
            return collection;
        }





        
    }
}

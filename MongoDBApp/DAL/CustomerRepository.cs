using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Shared;
using MongoDBApp.Models;
using MongoDB.Bson.Serialization;
using System.Windows;

namespace MongoDBApp.DAL
{


    public class CustomerRepository : IRepository<CustomerModel>
    {

        //Database connection string
        private static string connectionString = Properties.Settings.Default.ordersConnectionString;
        private static readonly CustomerRepository instance = new CustomerRepository();
        private static List<CustomerModel> customers = new List<CustomerModel>();


        static CustomerRepository()
        {
        }

        private CustomerRepository()
        {

        }

        public static CustomerRepository Instance
        {
            get
            {
                return instance;
            }
        }




        public CustomerModel GetByEmail(string email)
        {
            if (customers == null)
                LoadDb();
            return customers.Where(c => c.Email == email).FirstOrDefault();
        }

        public CustomerModel GetById(ObjectId id)
        {
            if (customers == null)
                LoadDb();
            return customers.Where(c => c.Id == id).FirstOrDefault();
        }

        public List<CustomerModel> GetAll()
        {
            if (customers.Count == 0)
                LoadDb();
            return customers;
        }

        public async Task Update(CustomerModel t)
        {
            var collection = StartConnection();
            var filter = Builders<CustomerModel>.Filter.Where(x => x.Id == t.Id);

            collection.Find(filter).ToString();
            var result = await collection.ReplaceOneAsync(filter, t, new UpdateOptions { IsUpsert = true });

            var index = customers.FindIndex(a => a.Id == t.Id);
            customers[index] = t;
        }

        public async Task Add(CustomerModel t)
        {
            var collection = StartConnection();
            await collection.InsertOneAsync(t);
            customers.Add(t);
        }

        public async Task Delete(CustomerModel t)
        {
            var collection = StartConnection();
            var filter = Builders<CustomerModel>.Filter.Where(x => x.Id == t.Id);
            var result = await collection.DeleteOneAsync(filter);
            customers.Remove(t);
        }

        public void LoadDb()
        {
            var collection = StartConnection();

            try
            {
                customers = collection.Find(new BsonDocument()).ToListAsync().GetAwaiter().GetResult();
            }
            catch (MongoException ex)
            {
                //Log exception here:
                MessageBox.Show("A connection error occurred: " + ex.Message, "Connection Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }



        public IMongoCollection<CustomerModel> StartConnection()
        {
              
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("orders");
            //Get a handle on the customers collection:
            var collection = database.GetCollection<CustomerModel>("customers");
            return collection;
        }
    }

}

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


    public class CustomerRepository : ICustomerRepository
    {

        //Database connection string
        private const string connectionString = "mongodb://brianVarley:Starlight123;@ds054118.mongolab.com:54118/orders";
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


        public CustomerModel GetACustomer()
        {
            if (customers == null)
                LoadCustomers();
            return customers.FirstOrDefault();
        }

        public List<CustomerModel> GetCustomers()
        {
            if (customers.Count == 0)
                LoadCustomers();
            return customers;
        }


        public CustomerModel GetCustomerById(ObjectId id)
        {
            if (customers == null)
                LoadCustomers();
            return customers.Where(c => c.Id == id).FirstOrDefault();
        }


        public CustomerModel GetCustomerByEmail(string email)
        {
            if (customers == null)
                LoadCustomers();
            return customers.Where(c => c.Email == email).FirstOrDefault();
        }

        public async Task DeleteCustomer(CustomerModel customer)
        {
            var collection = StartConnection();
            var filter = Builders<CustomerModel>.Filter.Where(x => x.Id == customer.Id);

            var result = await collection.DeleteOneAsync(filter);
            //refresh data set
            LoadCustomers();
        }

        public async Task AddCustomer(CustomerModel customer)
        {
            var collection = StartConnection();
            await collection.InsertOneAsync(customer);
            //refresh data set
            LoadCustomers();
        }


        public async Task UpdateCustomer(CustomerModel customer)
        {          
            var collection = StartConnection();
            var filter = Builders<CustomerModel>.Filter.Where(x => x.Id == customer.Id);

            collection.Find(filter).ToString();
            var result = await collection.ReplaceOneAsync(filter, customer, new UpdateOptions { IsUpsert = true });
            //refresh data set
            LoadCustomers();
        }


        private void LoadCustomers()
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

        private static IMongoCollection<CustomerModel> StartConnection()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("orders");
            //Get a handle on the customers collection:
            var collection = database.GetCollection<CustomerModel>("customers");
            return collection;
        }



       
    }

}

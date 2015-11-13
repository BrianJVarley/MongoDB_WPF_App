﻿using System;
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

namespace MongoDBApp.Services
{


    public class CustomerRepository : ICustomerRepository
    {

        //Database connection string
        private const string connectionString = "mongodb://<brianVarley>:<Starlight123;>@ds048878.mongolab.com:48878/orders/?connectTimeoutMS=600000";
        private static readonly CustomerRepository instance = new CustomerRepository();
        private static List<Customer> customers = new List<Customer>();


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

        public List<Customer> LoadCustomers()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("orders");
            //Get a handle on the customers collection:
            var collection = database.GetCollection<Customer>("customers");
            
            try
            {
                customers = collection.Find(new BsonDocument()).ToListAsync().GetAwaiter().GetResult();
               //var docs = BsonClassMap.RegisterClassMap<Customer>();

            }
            catch(MongoException ex)
            {
                //Log exception here:
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Connection Exception", MessageBoxButton.OK, MessageBoxImage.Warning);          
            }
            
            return customers;
        } 


        public void DeleteCustomer(Customer customer)
        {
            customers.Remove(customer);
        }

        public Customer GetCustomerByEmail(string email)
        {
            return customers.Where(c => c.Email == email).FirstOrDefault();
        }


        public void UpdateCustomer(Customer customer)
        {
            Customer customerToUpdate = customers.Where(c => c.Id == customer.Id).FirstOrDefault();
            customerToUpdate = customer;
        }

        /*
        public async static Task<List<Customer>> FindCustomers(IMongoCollection<BsonDocument> collection)
        {
            var documents =  await collection.Find(new BsonDocument()).ToListAsync();
            List<Customer> customerList = documents.ToList();

            return documents.ToList();
        }
         */

  

    }

}
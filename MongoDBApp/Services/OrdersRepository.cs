using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Shared;
using MongoDBApp.Models;

namespace MongoDBApp.Services
{


    public class OrdersRepository
    {

        //Database connection string
        const string connectionString = "mongodb://<brianVarley>:<Starlight123;>@ds048878.mongolab.com:48878/orders";



        //Method to create MongoDB Orders connection and get handle on collections
        public static bool CreateConnection()
        {
            
            var client = new MongoClient(connectionString);

            try
            {
              var database = client.GetDatabase("orders");
              //Get a handle on the customers collection:
              var collection = database.GetCollection<BsonDocument>("customers");
            }
            catch(MongoConnectionException)
            { 
                return false; 
            } 
                 
            return true; 
        }



        //Method to test query on database documents
        public async static Task<List<Customer>> FindCustomers()
        {
            var documents =  await collection.Find(new BsonDocument()).ToListAsync();
            List<Customer> customerList = await documents.ToListAsync();

            return await documents.ToListAsync();

        }
    

    }

}

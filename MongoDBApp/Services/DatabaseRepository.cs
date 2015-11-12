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


    public class DatabaseRepository
    {

        //Database connection string
        private const string connectionString = "mongodb://<brianVarley>:<Starlight123;>@ds048878.mongolab.com:48878/orders";
        private static readonly DatabaseRepository instance = new DatabaseRepository();


        static DatabaseRepository()
        {
        }

        private DatabaseRepository()
        {

        }

        public static DatabaseRepository Instance
        {
            get
            {
                return instance;
            }
        }

        public static IMongoCollection<BsonDocument> CreateConnection()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("orders");
            //Get a handle on the customers collection:
            return database.GetCollection<BsonDocument>("customers");
        }


        /*
        public async static Task<List<Customer>> FindCustomers(IMongoCollection<BsonDocument> collection)
        {
            var documents =  await collection.Find(new BsonDocument()).ToListAsync();
            List<Customer> customerList = documents.ToList();

            return documents.ToList();
        }
         */


        /*
        //Method to test query on database documents
        public async static Task<List<Customer>> FindCustomers()
        {
            var documents =  await collection.Find(new BsonDocument()).ToListAsync();
            List<Customer> customerList = await documents.ToListAsync();

            return await documents.ToListAsync();

        }
         */
    

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Shared;

namespace MongoDBApp.Services
{


    public class OrdersRepository
    {


        private string connectionString = "mongodb://<brianVarley>:<Starlight123;>@ds048878.mongolab.com:48878/orders";



        public static void connection()
        {

            MongoClient client = new MongoClient(connectionString);
            MongoClient database = client.GetDatabase("orders");

            //Get a handle on the customers collection:
            MongoClient collection = database.GetCollection<BsonDocument>("customers");
            //var documents = await collection.Find(new BsonDocument()).ToListAsync();

        }
       

    }
}

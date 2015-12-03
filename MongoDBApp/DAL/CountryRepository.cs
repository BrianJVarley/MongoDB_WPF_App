using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xceed.Wpf.Toolkit;

namespace MongoDBApp.DAL
{
    class CountryRepository : IRepository<CountryModel>
    {

         //Database connection string
        private static string connectionString = Properties.Settings.Default.ordersConnectionString;
        private static readonly CountryRepository instance = new CountryRepository();
        private static List<CountryModel> countries = new List<CountryModel>();


        static CountryRepository()
        {
        }

        private CountryRepository()
        {

        }

        public static CountryRepository Instance
        {
            get
            {
                return instance;
            }
        }


        public CountryModel GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public CountryModel GetById(MongoDB.Bson.ObjectId id)
        {
            throw new NotImplementedException();
        }

        public List<CountryModel> GetAll()
        {
            if (countries.Count == 0)
                LoadDb();
            return countries;
        }

        public Task Update(CountryModel t)
        {
            throw new NotImplementedException();
        }

        public Task Add(CountryModel t)
        {
            throw new NotImplementedException();
        }

        public Task Delete(CountryModel t)
        {
            throw new NotImplementedException();
        }

        public void LoadDb()
        {
            var collection = StartConnection();

            try
            {
                countries = collection.Find(new BsonDocument()).ToListAsync().GetAwaiter().GetResult();
            }
            catch (MongoException ex)
            {
                //Log exception here:
               System.Windows.MessageBox.Show("A connection error occurred: " + ex.Message, "Connection Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        public IMongoCollection<CountryModel> StartConnection()
        {
            
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("orders");
            //Get a handle on the countries collection:
            var collection = database.GetCollection<CountryModel>("countries");
            return collection;
        }
    }
}

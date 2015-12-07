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
    class CountryRepository : IRepository<Country>
    {

        //Database connection string
        private static string connectionString = Properties.Settings.Default.ordersConnectionString;
        private static readonly CountryRepository instance = new CountryRepository();
        private static List<Country> countryList = new List<Country>();


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



        public async Task<Country> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }


      

        public async Task<Country> GetByIdAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Country>> GetAllAsync()
        {
            if (countryList.Count == 0)
                await LoadDbAsync();
            return countryList;
        }

        public async Task UpdateAsync(Country t)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Country t)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Country t)
        {
            throw new NotImplementedException();
        }

        public async Task LoadDbAsync()
        {
            var collection = StartConnection();

            try
            {
                var result = await collection.Find(x => x.CountryObjectName == "CountryListObject").Project(x => x.Countries).FirstOrDefaultAsync();
                countryList = result;
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







        public Task<List<Country>> GetAllByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}

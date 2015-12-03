using MongoDBApp.DAL;
using MongoDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Services
{
    class CountryDataService : IDataService<CountryModel>
    {

        IRepository<CountryModel> repository;

        public CountryDataService(IRepository<CountryModel> repository)
        {
            this.repository = repository;  
        }



        public List<CountryModel> GetAll()
        {
            return repository.GetAll();
        }

        public CountryModel GetById(MongoDB.Bson.ObjectId id)
        {
            throw new NotImplementedException();
        }

        public CountryModel GetByEmail(string email)
        {
            throw new NotImplementedException();
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
    }
}

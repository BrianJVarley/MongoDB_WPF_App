using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBApp.DAL;
using MongoDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Mocks
{
    class MockRepository : IRepository<CustomerModel>
    {
        private List<CustomerModel> customers;

        public MockRepository()
        {
            customers = LoadMockCustomers();
        }


        private List<CustomerModel> LoadMockCustomers()
        {
            return new List<CustomerModel>()
			{
				new CustomerModel ()
				{
					FirstName = "Brian",
					LastName = "Varley",
					Email = "brian@gmail.com",                 
				},
				new CustomerModel ()
				{ 
					FirstName = "Patrick",
					LastName = "Darley",
					Email = "patd@gmail.com",              
				},
				new CustomerModel ()
				{ 
					FirstName = "John",
					LastName = "Carley",
					Email = "jc@gmail.com",              
				},
			};

        }


        public CustomerModel GetByEmail(string email)
        {
            if (customers == null)
                LoadMockCustomers();
            return customers.Where(c => c.Email == email).FirstOrDefault();
        }

        public CustomerModel GetById(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerModel> GetAll()
        {
            return customers;
        }

        public Task Update(CustomerModel customer)
        {
            throw new NotImplementedException();
        }

        public Task Delete(CustomerModel customer)
        {
            throw new NotImplementedException();
        }

        public Task Add(CustomerModel customer)
        {
            throw new NotImplementedException();
        }


        public void LoadDb()
        {
            throw new NotImplementedException();
        }

        public IMongoCollection<CustomerModel> StartConnection()
        {
            throw new NotImplementedException();
        }
    }
}

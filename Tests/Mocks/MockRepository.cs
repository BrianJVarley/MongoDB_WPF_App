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




        public async Task<CustomerModel> GetByEmailAsync(string email)
        {
             if (customers == null)
                LoadMockCustomers();
            return customers.Where(c => c.Email == email).FirstOrDefault();
        }

        public async Task<CustomerModel> GetByIdAsync(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerModel>> GetAllAsync()
        {
            return customers;
        }

        public async Task UpdateAsync(CustomerModel t)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(CustomerModel t)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(CustomerModel t)
        {
            throw new NotImplementedException();
        }

        public async Task LoadDbAsync()
        {
            throw new NotImplementedException();
        }






        public Task<List<CustomerModel>> GetAllByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}

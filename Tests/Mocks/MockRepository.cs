using MongoDB.Bson;
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


        public CustomerModel GetCustomerByEmail(string email)
        {
            if (customers == null)
                LoadMockCustomers();
            return customers.Where(c => c.Email == email).FirstOrDefault();
        }

        public CustomerModel GetCustomerById(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerModel> GetCustomers()
        {
            return customers;
        }

        public Task UpdateCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }

        public Task AddCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }
    }
}

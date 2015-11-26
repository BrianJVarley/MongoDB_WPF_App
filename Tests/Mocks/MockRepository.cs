using MongoDBApp.DAL;
using MongoDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Mocks
{
    class MockRepository : ICustomerRepository
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
					FirstName = "Brian",
					LastName = "Varley",
					Email = "brian@gmail.com",              
				},
				new CustomerModel ()
				{ 
					FirstName = "Brian",
					LastName = "Varley",
					Email = "brian@gmail.com",              
				},
			};

        }



        public void DeleteCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetACustomer()
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetCustomerByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetCustomerById(MongoDB.Bson.ObjectId id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerModel> GetCustomers()
        {
            throw new NotImplementedException();
        }




        public Task UpdateCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }

        Task ICustomerRepository.DeleteCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }

        public Task AddCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }
    }
}

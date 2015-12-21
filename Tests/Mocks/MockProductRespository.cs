using MongoDBApp.DAL;
using MongoDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Mocks
{
    public class MockProductRespository : IRepository<ProductModel>
    {


        private List<ProductModel> products;

        public MockProductRespository()
        {
            products = LoadMockProducts();
        }


        private List<ProductModel> LoadMockProducts()
        {
            return new List<ProductModel>()
			{
				new ProductModel ()
				{ 
					ProductId = "2033",
					Description = "Coffee latte - medium",
					Price = 20.5f,   
                    Available = 36,
					Quantity = 12,  
				},
				new ProductModel ()
				{ 
					ProductId = "2034",
					Description = "Cider cold - large",
					Price = 20.5f,   
                    Available = 36,
					Quantity = 12,  
				},
				new ProductModel ()
				{ 
					ProductId = "2033",
					Description = "Carrot cake - large",
					Price = 20.5f,   
                    Available = 36,
					Quantity = 12,  
				},
			};

        }



        public Task<ProductModel> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> GetAllByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetByIdAsync(MongoDB.Bson.ObjectId id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductModel>> GetAllAsync()
        {
            return products;
        }

        public Task UpdateAsync(ProductModel t)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(ProductModel t)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ProductModel t)
        {
            throw new NotImplementedException();
        }

        public Task LoadDbAsync()
        {
            throw new NotImplementedException();
        }
    }
}

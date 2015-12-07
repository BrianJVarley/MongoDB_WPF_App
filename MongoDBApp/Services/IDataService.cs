using MongoDB.Bson;
using MongoDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Services
{
    public interface IDataService<T> where T : new()
    {

        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(ObjectId id);
        Task<T> GetByEmailAsync(string email);
        Task<List<T>> GetAllByEmailAsync(string email);
        Task UpdateAsync(T t);
        Task AddAsync(T t);
        Task DeleteAsync(T t);
   
    }
}

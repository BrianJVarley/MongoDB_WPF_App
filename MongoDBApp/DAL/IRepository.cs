using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.DAL
{
    public interface IRepository<T> where T : new()
    {

        Task<T> GetByEmailAsync(string email);
        Task<List<T>> GetAllByEmailAsync(string email);
        Task<T> GetByIdAsync(ObjectId id);
        Task <List<T>> GetAllAsync();
        Task UpdateAsync(T t);
        Task AddAsync(T t);
        Task DeleteAsync(T t);
        Task LoadDbAsync();

    }
}

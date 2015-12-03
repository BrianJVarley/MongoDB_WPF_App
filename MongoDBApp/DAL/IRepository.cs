using MongoDB.Bson;
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
        
        T GetByEmail(string email);
        T GetById(ObjectId id);
        List<T> GetAll();
        Task Update(T t);
        Task Add(T t);
        Task Delete(T t);
        void LoadDb();

    }
}

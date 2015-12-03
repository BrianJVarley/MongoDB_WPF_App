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
         
        List<T> GetAll();
        T GetById(ObjectId id);
        T GetByEmail(string email);
        Task Update(T t);
        Task Add(T t);
        Task Delete(T t);
   
    }
}

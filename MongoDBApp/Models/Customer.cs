using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Models
{
    public class Customer
    {
        /// <summary>
        /// This attribute is used to map the Id property to the ObjectId in the collection
        /// </summary>
        [BsonId]
        public ObjectId Id { get; set; }

      
        [BsonElement("fisrtName")]
        public string firstName { get; set; }

        [BsonElement("lastName")]
        public string lastName { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

    }
}

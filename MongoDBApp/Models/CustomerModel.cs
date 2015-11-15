using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Models
{
    public class CustomerModel
    {
        
        [BsonElement]
        ObservableCollection<CustomerModel> customers { get; set; }

        /// <summary>
        /// This attribute is used to map the Id property to the ObjectId in the collection
        /// </summary>
        [BsonId]
        public ObjectId Id { get; set; }
      
        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

    }
}

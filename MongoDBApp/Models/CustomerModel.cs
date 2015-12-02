using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Models
{
    [ImplementPropertyChanged]
    public class CustomerModel 
    {

  
       
        [BsonId]
        public ObjectId Id { get; set; }
        
      
        [BsonElement("firstName")]
        public string FirstName { get; set; }
        
        [BsonElement("lastName")]
        public string LastName { get; set; }
        

        [BsonElement("email")]
        public string Email { get; set; }
        
        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }


        public override string ToString()
        {
            return Country;
        }

    }
}

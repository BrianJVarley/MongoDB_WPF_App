using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDBApp.Models;
using System.Threading.Tasks;
using System.ComponentModel;
using MongoDB.Bson.Serialization.Attributes;
using PropertyChanged;

namespace MongoDBApp.Models
{
    [ImplementPropertyChanged]
    public class OrderModel 
    {

        
        [BsonId]
        public ObjectId Id { get; set; }
        

        [BsonElement("email")]
        public string Email { get; set; }
        

        [BsonElement("date")]
        public BsonDateTime Date { get; set; }
       


        [BsonElement("status")]
        public Boolean Status { get; set; }
        

        [BsonElement("products")]
        public ProductModel[] Products { get; set; }
      


       
    }

}

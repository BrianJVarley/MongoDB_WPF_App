using MongoDB.Bson.Serialization.Attributes;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Models
{
    
    [ImplementPropertyChanged]
    public class ProductModel 
    {


        [BsonElement("productId")]
        public string ProductId { get; set; }
        
        [BsonElement("price")]
        public float Price { get; set; }
      

        [BsonElement("description")]
        public string Description { get; set; }
     
    }
}

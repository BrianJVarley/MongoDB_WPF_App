using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Models
{
    [ImplementPropertyChanged]
    public class CountryModel
    {

        
      
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string CountryObjectName { get; set; }


        [BsonElement("countries")]
        public List<Country> Countries { get; set; }
        
       

    }

    [BsonIgnoreExtraElements]
    [ImplementPropertyChanged]
    public class Country
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("code")]
        public string Code { get; set; }
    }
}

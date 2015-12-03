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
        public ObjectId Id { get; set; }

        [BsonElement("countries")]
        public List<Country> countries { get; set; }
        
       

    }

    [ImplementPropertyChanged]
    public class Country
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("code")]
        public string Code { get; set; }
    }
}

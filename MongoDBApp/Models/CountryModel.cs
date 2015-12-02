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
    class CountryModel
    {
        [BsonElement("name")]
        public float Name { get; set; }

        [BsonElement("code")]
        public string Code { get; set; }

    }
}

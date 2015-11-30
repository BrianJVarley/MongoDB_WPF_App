using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBApp.Models
{
    public class ProductModel : INotifyPropertyChanged
    {

        private string productId;
        private float price;
        private string description;


        


        [BsonElement("productId")]
        public string ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
                RaisePropertyChanged("ProductId");
            }
        }

        [BsonElement("price")]
        public float Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                RaisePropertyChanged("Price");
            }
        }

        [BsonElement("description")]
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                RaisePropertyChanged("Description");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDBApp.Models;
using System.Threading.Tasks;
using System.ComponentModel;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBApp.Models
{
    public class OrderModel : INotifyPropertyChanged
    {

        private ObjectId _id;
        private string email;
        private BsonDateTime date;
        private ProductModel[] products;


        [BsonId]
        public ObjectId Id
        {
            get
            {
                return _id;
            }
            set
            {

                _id = value;
            }
        }





        [BsonElement("email")]
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                RaisePropertyChanged("Email");
            }
        }



        [BsonElement("date")]
        public BsonDateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                RaisePropertyChanged("Date");
            }
        }


        [BsonElement("products")]
        public ProductModel[] Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
                RaisePropertyChanged("Products");
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

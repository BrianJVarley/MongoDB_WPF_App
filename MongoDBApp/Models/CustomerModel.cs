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
    public class CustomerModel : INotifyPropertyChanged
    {

        private ObjectId id;
        private string firstName;
        private string lastName;
        private string email;

        
        [BsonElement]
        ObservableCollection<CustomerModel> customers { get; set; }
        

        /// <summary>
        /// This attribute is used to map the Id property to the ObjectId in the collection
        /// </summary>
        [BsonId]
        public ObjectId Id 
        {
            get
            {
                return id;
            }
            set
            {

                id = value;
            }
        }
      
        [BsonElement("firstName")]
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        [BsonElement("lastName")]
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                RaisePropertyChanged("LastName");
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

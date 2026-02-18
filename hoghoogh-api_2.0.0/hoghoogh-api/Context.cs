using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hoghoogh_api
{
    public class Context
    {
        private readonly IMongoDatabase database;
        public Context()
        {
            database = new MongoClient("mongodb://localhost:27017").GetDatabase("hoghooghi");
        }
        
        public IMongoCollection<Models.User> User
        {
            get
            {
                return database.GetCollection<Models.User>("User");
            }

        }
        public IMongoCollection<Models.Log> Log
        {
            get
            {
                return database.GetCollection<Models.Log>("Log");
            }

        }
        public IMongoCollection<Models.Home> Home
        {
            get
            {
                return database.GetCollection<Models.Home>("Home");
            }

        }
        public IMongoCollection<Models.Mail> Mail
        {
            get
            {
                return database.GetCollection<Models.Mail>("Mail");
            }

        }
        public IMongoCollection<Models.Data_U_S> Data_U_S
        {
            get
            {
                return database.GetCollection<Models.Data_U_S>("Data_U_S");
            }

        }

    }
}

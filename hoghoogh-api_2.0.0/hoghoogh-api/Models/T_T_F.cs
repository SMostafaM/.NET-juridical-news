using Microsoft.AspNetCore.Http;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hoghoogh_api.Models
{
    public class T_T_F
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string txt { get; set; }
        public string title { get; set; }
        public string file_address { get; set; }
        public IFormFile file { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace hoghoogh_api.Models
{
    public class Home
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public Models.M1_4_lttf M1_L_4 { get; set; }
        public Models.L_T_T_F M2 { get; set; }
        public Models.L_T_T_F M3 { get; set; }
        public Models.L_T_T_F M4 { get; set; }
        public Models.L_T_T_F M5 { get; set; }
        public Models.L_T_T_F left_1 { get; set; }
        public Models.L_T_T_F left_2 { get; set; }
        public Models.L_T_T_F left_3 { get; set; }
        public Models.new_news_mini H_new { get; set; }
        public Models.L_T_T_F news { get; set; }
        public Models.L_T_T_F slider { get; set; }
        public Models.L_T_T_F left_img { get; set; }
        public Models.L_T_T_F video { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hoghoogh_api.Models
{
    public class M1_4_lttf
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string name { get; set; }
        public Models.L_T_T_F L_t_t_f_1 { get; set; }
        public Models.L_T_T_F L_t_t_f_2 { get; set; }
        public Models.L_T_T_F L_t_t_f_3 { get; set; }
        public Models.L_T_T_F L_t_t_f_4 { get; set; }
    }
}

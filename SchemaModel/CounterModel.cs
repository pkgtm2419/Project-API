﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectAPI.SchemaModel
{
    public class CounterModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("count")]
        public int Count { get; set; }
    }

    public class CounterRes
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<CounterModel> data { get; set; }
    }

}

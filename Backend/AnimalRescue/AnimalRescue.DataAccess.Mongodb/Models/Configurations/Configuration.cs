﻿using AnimalRescue.DataAccess.Mongodb.Attributes;
using AnimalRescue.DataAccess.Mongodb.Models.BaseItems;

using MongoDB.Bson.Serialization.Attributes;

using common = AnimalRescue.Contracts.Common.Constants.PropertyConstants.Common;

namespace AnimalRescue.DataAccess.Mongodb.Models.Configurations
{
    [BsonDiscriminator("configurations")]
    public class Configuration<T> : BaseAndTimeItem
    {
        [CouplingPropertyName(common.Name)]
        [BsonElement("name")]
        public string Name { get; set; }

        [CouplingPropertyName(common.Data)]
        [BsonElement("data")]
        public T Data { get; set; }
    }
}

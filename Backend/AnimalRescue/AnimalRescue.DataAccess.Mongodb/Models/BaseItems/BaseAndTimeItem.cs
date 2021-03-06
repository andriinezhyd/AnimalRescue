﻿using AnimalRescue.DataAccess.Mongodb.Attributes;

using MongoDB.Bson.Serialization.Attributes;

using System;

using baseItem = AnimalRescue.Contracts.Common.Constants.PropertyConstants.BaseItem;

namespace AnimalRescue.DataAccess.Mongodb.Models.BaseItems
{
    public class BaseAndTimeItem  : BaseItem
    {
        [CouplingPropertyName(baseItem.CreatedAt)]
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [CouplingPropertyName(baseItem.ModifiedAt)]
        [BsonElement("modifiedAt")]
        public DateTime? ModifiedAt { get; set; }

        [CouplingPropertyName(baseItem.CreatedBy)]
        [BsonElement("createdBy")]
        public string CreatedBy { get; set; }

        [CouplingPropertyName(baseItem.ModifiedBy)]
        [BsonElement("modifiedBy")]
        public string ModifiedBy { get; set; }  
    }
}

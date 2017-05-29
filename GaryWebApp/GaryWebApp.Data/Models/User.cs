﻿using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GaryWebApp.Data.Models
{
    public class User
    {
        [BsonId]
        public string Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

    }
}

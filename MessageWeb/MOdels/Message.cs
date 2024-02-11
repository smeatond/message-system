using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MessageWeb.Models;

public class Message
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string MessageText { get; set; } = null!;

    public string Username { get; set; } = null!;

    public DateTime DateTime { get; set; }
}
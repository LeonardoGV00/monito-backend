using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MonitoNet.Backend.Iam.Domain.Model.Enums;
using System.Text.Json.Serialization;

namespace MonitoNet.Backend.Iam.Domain.Model.Aggregates;

public sealed class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonElement("username")]
    public string Username { get; set; } = string.Empty;

    [BsonElement("email")]
    public string Email { get; set; } = string.Empty;

    [JsonIgnore]
    [BsonElement("password")]
    public string Password { get; set; } = string.Empty;

    [BsonElement("rol")]
    [BsonRepresentation(BsonType.String)]
    public UserRole Rol { get; set; } = UserRole.cliente;

    [BsonElement("telefono")]
    public string Telefono { get; set; } = string.Empty;

    [BsonElement("picture")]
    public string Picture { get; set; } = string.Empty;

    [BsonElement("followers")]
    public int Followers { get; set; }

    [BsonElement("fechaRegistro")]
    public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
}

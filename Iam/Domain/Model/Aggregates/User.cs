using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MonitoNet.Backend.Iam.Domain.Model.Aggregates;

public sealed class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    [JsonIgnore]
    public string Password { get; set; } = string.Empty;

    public string Rol { get; set; } = "cliente";
    public string Telefono { get; set; } = string.Empty;
    public string Picture { get; set; } = string.Empty;
    public int Followers { get; set; }
    public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
}

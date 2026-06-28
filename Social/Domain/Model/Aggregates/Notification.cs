using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MonitoNet.Backend.Social.Domain.Model.Enums;

namespace MonitoNet.Backend.Social.Domain.Model.Aggregates;

public sealed class Notification
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonRepresentation(BsonType.ObjectId)]
    public string UsuarioId { get; set; } = string.Empty;

    public NotificationType Tipo { get; set; }
    public string Mensaje { get; set; } = string.Empty;
    public bool Leido { get; set; }
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MonitoNet.Backend.Social.Domain.Model.Enums;

namespace MonitoNet.Backend.Social.Domain.Model.Aggregates;

public sealed class Notification
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonElement("usuarioId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string UsuarioId { get; set; } = string.Empty;

    [BsonElement("tipo")]
    [BsonRepresentation(BsonType.String)]
    public NotificationType Tipo { get; set; }

    [BsonElement("mensaje")]
    public string Mensaje { get; set; } = string.Empty;

    [BsonElement("leido")]
    public bool Leido { get; set; }

    [BsonElement("fecha")]
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MonitoNet.Backend.Social.Domain.Model.Entities;

public sealed class PublicationComment
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonRepresentation(BsonType.ObjectId)]
    public string UsuarioId { get; set; } = string.Empty;

    public string Comentario { get; set; } = string.Empty;
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public List<CommentReply> Respuestas { get; set; } = [];
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MonitoNet.Backend.Social.Domain.Model.Entities;

public sealed class PublicationComment
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonElement("usuarioId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string UsuarioId { get; set; } = string.Empty;

    [BsonElement("comentario")]
    public string Comentario { get; set; } = string.Empty;

    [BsonElement("fecha")]
    public DateTime Fecha { get; set; } = DateTime.UtcNow;

    [BsonElement("respuestas")]
    public List<CommentReply> Respuestas { get; set; } = [];
}

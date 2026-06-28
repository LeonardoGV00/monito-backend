using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MonitoNet.Backend.Social.Domain.Model.Entities;

namespace MonitoNet.Backend.Social.Domain.Model.Aggregates;

public sealed class Publication
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonRepresentation(BsonType.ObjectId)]
    public string AutorId { get; set; } = string.Empty;

    [BsonRepresentation(BsonType.ObjectId)]
    public string? ProductoRelacionadoId { get; set; }

    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public List<PublicationMedia> Multimedia { get; set; } = [];
    public int Likes { get; set; }
    public List<PublicationComment> Comentarios { get; set; } = [];
    public DateTime FechaPublicacion { get; set; } = DateTime.UtcNow;
}

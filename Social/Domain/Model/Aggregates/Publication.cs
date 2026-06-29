using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MonitoNet.Backend.Social.Domain.Model.Entities;

namespace MonitoNet.Backend.Social.Domain.Model.Aggregates;

public sealed class Publication
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonElement("autorId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string AutorId { get; set; } = string.Empty;

    [BsonElement("productoRelacionadoId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ProductoRelacionadoId { get; set; }

    [BsonElement("titulo")]
    public string Titulo { get; set; } = string.Empty;

    [BsonElement("descripcion")]
    public string Descripcion { get; set; } = string.Empty;

    [BsonElement("multimedia")]
    public List<PublicationMedia> Multimedia { get; set; } = [];

    [BsonElement("likes")]
    public int Likes { get; set; }

    [BsonElement("comentarios")]
    public List<PublicationComment> Comentarios { get; set; } = [];

    [BsonElement("fechaPublicacion")]
    public DateTime FechaPublicacion { get; set; } = DateTime.UtcNow;
}

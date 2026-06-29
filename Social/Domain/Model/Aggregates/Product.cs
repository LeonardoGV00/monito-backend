using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MonitoNet.Backend.Social.Domain.Model.Aggregates;

public sealed class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonElement("nombre")]
    public string Nombre { get; set; } = string.Empty;

    [BsonElement("descripcion")]
    public string Descripcion { get; set; } = string.Empty;

    [BsonElement("categoria")]
    public string Categoria { get; set; } = string.Empty;

    [BsonElement("precio")]
    public decimal Precio { get; set; }

    [BsonElement("stock")]
    public int Stock { get; set; }

    [BsonElement("imagen")]
    public string Imagen { get; set; } = string.Empty;
}

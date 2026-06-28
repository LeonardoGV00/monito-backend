using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MonitoNet.Backend.Social.Domain.Model.Aggregates;

public sealed class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public string Imagen { get; set; } = string.Empty;
}

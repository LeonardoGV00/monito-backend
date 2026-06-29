using MongoDB.Bson.Serialization.Attributes;

namespace MonitoNet.Backend.Social.Domain.Model.Commands;

public sealed class PublicationMediaCommand
{
    [BsonElement("tipo")]
    public string Tipo { get; set; } = string.Empty;

    [BsonElement("url")]
    public string Url { get; set; } = string.Empty;

    [BsonElement("formato")]
    public string Formato { get; set; } = string.Empty;
}

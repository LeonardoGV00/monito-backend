using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace MonitoNet.Backend.Social.Domain.Model.Commands;

public sealed class PublicationMediaCommand
{
    [Required]
    [MinLength(1)]
    [BsonElement("tipo")]
    public string Tipo { get; set; } = string.Empty;

    [Required]
    [MinLength(1)]
    [BsonElement("url")]
    public string Url { get; set; } = string.Empty;

    [Required]
    [MinLength(1)]
    [BsonElement("formato")]
    public string Formato { get; set; } = string.Empty;
}

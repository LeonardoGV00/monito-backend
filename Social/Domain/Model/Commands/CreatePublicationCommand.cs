using System.ComponentModel.DataAnnotations;

namespace MonitoNet.Backend.Social.Domain.Model.Commands;

public sealed class CreatePublicationCommand
{
    [Required]
    public string AutorId { get; set; } = string.Empty;

    [Required]
    public string ProductoRelacionadoId { get; set; } = string.Empty;

    [Required]
    [MinLength(1)]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    [MinLength(1)]
    public string Descripcion { get; set; } = string.Empty;

    public List<PublicationMediaCommand>? Multimedia { get; set; }
}

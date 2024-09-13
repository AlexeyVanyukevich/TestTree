using System.ComponentModel.DataAnnotations;

namespace Tree.API.Endpoints.Nodes.Models;

internal sealed class CreateNodeRequest {
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
}

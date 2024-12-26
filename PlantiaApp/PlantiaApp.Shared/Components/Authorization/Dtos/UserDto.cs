using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantiaApp.Shared.Components.Authorization.Dtos
{
    public record UserDto
    {
        public Guid Id { get; set; }
        public string? AvatarImage { get; set; } = string.Empty;
        public required string Username { get; set; } = string.Empty;
    }
}

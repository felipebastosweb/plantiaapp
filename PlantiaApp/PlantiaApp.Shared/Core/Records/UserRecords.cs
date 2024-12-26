using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantiaApp.Shared.Core.Records
{
    public class UserInput
    {
        public Guid? Id { get; set; } = null;
        public string? Username { get; set; }
        public string? Password { get; set; }
    }


    public class UserOutput
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }


}

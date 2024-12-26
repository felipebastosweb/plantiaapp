namespace PlantiaApp.Shared.Components.Authorization.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


using PlantiaApp.Shared.Core.Entities;

public class User : BaseEntity
{
    [Unique] public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public List<UserEmail>? Emails { get; set; }
    public List<UserTelephone>? Telephones { get; set; }
}

public class UserAvatar : BaseEntity
{
    public Guid UserId { get; set; }
    public required string AvatarImage {  get; set; }
    public bool Enabled { get; set; }
    public bool IsMain { get; set; }
}

public class UserEmail : BaseEntity
{
    public Guid UserId {  get; set; }
    [Unique] public required string Email { get; set; }
    public bool Enabled { get; set; }
    public bool IsMain { get; set; }
}

public class UserTelephone : BaseEntity
{
    public Guid UserId { get; set; }
    [Unique] public required string Telephone { get; set; }
    public bool Enabled { get; set; }
    public bool IsMain { get; set; }
}
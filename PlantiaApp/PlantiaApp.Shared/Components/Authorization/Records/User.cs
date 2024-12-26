﻿namespace PlantiaApp.Shared.Components.Authorization.Records;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record SignUpInput
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? RepeatPassword { get; set; }
    public bool AcceptTerms { get; set; }
}

public record LoginInput
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public bool KeepConnected { get; set; }
}


public record RescueAccountInput
{
    public string? Email { get; set; }
}
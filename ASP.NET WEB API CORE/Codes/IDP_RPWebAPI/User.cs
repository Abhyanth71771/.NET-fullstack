using System;
using System.Collections.Generic;

namespace IDP_RPWebAPI;

public partial class User
{
    public string Username { get; set; } = null!;

    public string? Pwd { get; set; }

    public string? Email { get; set; }

    public string? Userrole { get; set; }
}

using System;
using System.Collections.Generic;

namespace IDP_RPWebAPI;

public partial class Customer
{
    public int Custid { get; set; }

    public string? Custname { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}

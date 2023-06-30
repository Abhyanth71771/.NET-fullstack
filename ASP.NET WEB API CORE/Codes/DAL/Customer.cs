using System;
using System.Collections.Generic;

namespace DAL;

public partial class Customer
{
    public int Custid { get; set; }

    public string? Custname { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}

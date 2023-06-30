using System;
using System.Collections.Generic;

namespace IDP_RPWebAPI;

public partial class Order
{
    public int Orderid { get; set; }

    public string? Ordername { get; set; }

    public int? Custid { get; set; }

    public virtual Customer? Cust { get; set; }
}

using System;
using System.Collections.Generic;

namespace prjRestaurantManagementSystem.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public string ItemName { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Order Order { get; set; } = null!;
}

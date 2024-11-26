using System;
using System.Collections.Generic;

namespace Harmic.Models;

public partial class TbCart
{
    public int CartId { get; set; }

    public int? ProductId { get; set; }

    public string? Image { get; set; }

    public string? Title { get; set; }

    public int? Price { get; set; }

    public int? PriceSale { get; set; }

    public int? Quantity { get; set; }


    public DateTime? CreatedDate { get; set; }

    public virtual TbProduct? Product { get; set; }
}

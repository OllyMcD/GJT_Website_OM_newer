using System;
using System.Collections.Generic;

namespace GJT_Website_OM.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int UserId { get; set; }

    public string Money { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

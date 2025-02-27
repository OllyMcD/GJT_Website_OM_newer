using System;
using System.Collections.Generic;

namespace GJT_Website_OM.Models;

public partial class Usercertificate
{
    public int CertificateId { get; set; }

    public int UserId { get; set; }

    public string Topic { get; set; } = null!;

    public int Difficulty { get; set; }

    public string BadgeLevel { get; set; } = null!;

    public DateTime? DateEarned { get; set; }

    public virtual User User { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace GJT_Website_OM.Models;

public partial class Quiz
{
    public int QuizId { get; set; }

    public string Subject { get; set; } = null!;

    public int Difficuilty { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}

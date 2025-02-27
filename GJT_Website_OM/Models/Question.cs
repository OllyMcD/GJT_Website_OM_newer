using System;
using System.Collections.Generic;

namespace GJT_Website_OM.Models;

public partial class Question
{
    public int QuestionsId { get; set; }

    public int QuizId { get; set; }

    public string Question1 { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public virtual Quiz Quiz { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Definition
{
    public Guid Id { get; set; }

    public int Wordid { get; set; }

    public string Text { get; set; } = null!;
}

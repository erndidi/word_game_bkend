using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Word
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public int? Length { get; set; }
}

﻿using System;
using System.Collections.Generic;

namespace Notes.API.Models;

public partial class Note
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }
}

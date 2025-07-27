﻿using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class CourtReview
{
    public int ReviewId { get; set; }

    public int CourtId { get; set; }

    public int UserId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? ReviewDate { get; set; }

    public virtual Court Court { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

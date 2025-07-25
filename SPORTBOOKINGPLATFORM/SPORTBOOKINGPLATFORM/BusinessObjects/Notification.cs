﻿using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Notification
{
    public int NotificationId { get; set; }

    public int? UserId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsRead { get; set; }

    public virtual User? User { get; set; }
}

﻿using System;
using Microsoft.AspNetCore.Identity;

namespace Porto.Api.Models
{
    public class User : IdentityUser<long>, IEntityWithTypedId<long>, IEntityDate, IEntityEnabled, IEntityDeleted
    {
        public User()
        {
            var currentTime = DateTimeOffset.Now;

            CreatedAt = CreatedAt == default ? currentTime : CreatedAt;
            UpdatedAt = UpdatedAt == default ? currentTime : UpdatedAt;
        }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public bool Enabled { get; set; }

        public bool IsDeleted { get; set; }
    }
}

﻿using GameAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameAPI.Infrastructure
{
    public sealed class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<GameEntity> Games { get; set; } = null!;
        public DbSet<DeveloperEntity> Developers { get; set; } = null!;
        public DbSet<GenreEntity> Genres { get; set; } = null!;
    }
}

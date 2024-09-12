﻿using Microsoft.EntityFrameworkCore;

namespace Tree.Persistence;

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) : base( options ) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
    }
}

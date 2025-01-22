using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Notes.API.Models;

public partial class Subscription1DbContext : DbContext
{
    public Subscription1DbContext()
    {
    }

    public Subscription1DbContext(DbContextOptions<Subscription1DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Note> Notes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Subscription1DB;Integrated security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>(entity =>
        {
            entity.ToTable("Notes", "Notes");

            entity.Property(e => e.Content).HasMaxLength(1024);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

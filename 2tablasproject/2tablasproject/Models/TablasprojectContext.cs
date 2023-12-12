using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using tablasproject.Models;

namespace tablasproject.Models;

public partial class TablasprojectContext : DbContext
{
    public TablasprojectContext()
    {
    }

    public TablasprojectContext(DbContextOptions<TablasprojectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cardclass> Cardclass { get; set; }

    public virtual DbSet<Personaldata> Personaldata { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("SERVER=localhost;PORT=3306;DATABASE=tablasproject;USER=root;PASSWORD=;SSL MODE=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cardclass>(entity =>
        {
            entity.HasKey(e => e.CardId).HasName("PRIMARY");

            entity.ToTable("cardclass");

            entity.Property(e => e.CardId).HasColumnType("int(11)");
            entity.Property(e => e.CardNumber).HasColumnType("int(11)");
            entity.Property(e => e.CardTypeName).HasMaxLength(128);
            entity.Property(e => e.CurrencyAmmount).HasColumnType("int(11)");
            entity.Property(e => e.CurrencyName).HasMaxLength(128);
        });

        modelBuilder.Entity<Personaldata>(entity =>
        {
            entity.HasKey(e => e.PersonalId).HasName("PRIMARY");

            entity.ToTable("personaldata");

            entity.HasIndex(e => e.CardIndexId, "CardIndexId");

            entity.Property(e => e.PersonalId).HasColumnType("int(11)");
            entity.Property(e => e.CardIndexId).HasColumnType("int(11)");
            entity.Property(e => e.FirstName).HasMaxLength(128);
            entity.Property(e => e.Gender).HasMaxLength(32);
            entity.Property(e => e.Language).HasMaxLength(128);
            entity.Property(e => e.LastName).HasMaxLength(128);

            entity.HasOne(d => d.CardIndex).WithMany(p => p.Personaldata)
                .HasForeignKey(d => d.CardIndexId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("personaldata_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

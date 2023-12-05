using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

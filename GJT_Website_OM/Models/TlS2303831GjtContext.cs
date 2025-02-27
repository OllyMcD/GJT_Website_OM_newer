using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace GJT_Website_OM.Models;

public partial class TlS2303831GjtContext : DbContext
{
    public TlS2303831GjtContext()
    {
    }

    public TlS2303831GjtContext(DbContextOptions<TlS2303831GjtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Usercertificate> Usercertificates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("name=MySqlConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PRIMARY");

            entity.ToTable("payments");

            entity.HasIndex(e => e.UserId, "useridfk2_idx");

            entity.Property(e => e.PaymentId).HasColumnName("paymentID");
            entity.Property(e => e.Money)
                .HasMaxLength(45)
                .HasColumnName("money");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.User).WithMany(p => p.Payments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("useridfk2");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionsId).HasName("PRIMARY");

            entity.ToTable("questions");

            entity.HasIndex(e => e.QuizId, "quiz_idx");

            entity.Property(e => e.QuestionsId).HasColumnName("questionsID");
            entity.Property(e => e.Answer)
                .HasMaxLength(255)
                .HasColumnName("answer");
            entity.Property(e => e.Question1)
                .HasMaxLength(255)
                .HasColumnName("question");
            entity.Property(e => e.QuizId).HasColumnName("quizID");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("quiz_fk1");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.QuizId).HasName("PRIMARY");

            entity.ToTable("quiz");

            entity.Property(e => e.QuizId).HasColumnName("quizID");
            entity.Property(e => e.Difficuilty).HasColumnName("difficuilty");
            entity.Property(e => e.Subject)
                .HasMaxLength(45)
                .HasColumnName("subject");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "username_UNIQUE").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .HasColumnName("lastName");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Postcode)
                .HasMaxLength(10)
                .HasColumnName("postcode");
            entity.Property(e => e.ProgressComputing)
                .HasDefaultValueSql("'0'")
                .HasColumnName("progress_computing");
            entity.Property(e => e.ProgressMaths)
                .HasDefaultValueSql("'0'")
                .HasColumnName("progress_maths");
            entity.Property(e => e.ProgressPhysics)
                .HasDefaultValueSql("'0'")
                .HasColumnName("progress_physics");
            entity.Property(e => e.Score)
                .HasDefaultValueSql("'0'")
                .HasColumnName("score");
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Usercertificate>(entity =>
        {
            entity.HasKey(e => e.CertificateId).HasName("PRIMARY");

            entity.ToTable("usercertificates");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.BadgeLevel).HasColumnType("enum('Bronze','Silver','Gold','Master','Allstar')");
            entity.Property(e => e.DateEarned)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Topic).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.Usercertificates)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usercertificates_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AgriReachWeb.Models;

public partial class AgriReachDbContext : DbContext
{
    public AgriReachDbContext()
    {
    }

    public AgriReachDbContext(DbContextOptions<AgriReachDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Farm> Farms { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Produce> Produces { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ShoppingList> ShoppingLists { get; set; }

    public virtual DbSet<ShoppingListItem> ShoppingListItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:agri-reach-sv.database.windows.net,1433;Initial Catalog=AgriReachDB;Persist Security Info=False;User ID=agrireach-db;Password=P@ssword1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Farm>(entity =>
        {
            entity.HasKey(e => e.FarmId).HasName("PK__Farms__ED7BBA995F83201E");

            entity.Property(e => e.FarmId).HasColumnName("FarmID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DateRegistered)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FarmName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Parish)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            //entity.HasOne(d => d.User).WithMany(p => p.Farms)
            //    .HasForeignKey(d => d.UserId)
            //    .HasConstraintName("FK_Farms_Users");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Messages__C87C037C93E012BE");

            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.DateSent)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MessageText)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ReceiverId).HasColumnName("ReceiverID");
            entity.Property(e => e.SenderId).HasColumnName("SenderID");

            entity.HasOne(d => d.Receiver).WithMany(p => p.MessageReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_Receiver");

            entity.HasOne(d => d.Sender).WithMany(p => p.MessageSenders)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK_Messages_Sender");
        });

        modelBuilder.Entity<Produce>(entity =>
        {
            entity.HasKey(e => e.FarmProductId).HasName("PK__FarmProd__0065724677D12861");

            entity.ToTable("Produce");

            entity.Property(e => e.FarmProductId).HasColumnName("FarmProductID");
            entity.Property(e => e.AvailabilityStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BasePrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FarmId).HasColumnName("FarmID");
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            //entity.HasOne(d => d.Farm).WithMany(p => p.Produces)
            //    .HasForeignKey(d => d.FarmId)
            //    .HasConstraintName("FK_FarmProducts_Farm");

            //entity.HasOne(d => d.Product).WithMany(p => p.Produces)
            //    .HasForeignKey(d => d.ProductId)
            //    .HasConstraintName("FK_FarmProducts_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED86EE0BBE");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            //entity.Property(e => e.Category)
            //    .HasMaxLength(100)
            //    .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AE6CE73538");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.DatePosted)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FarmId).HasColumnName("FarmID");
            entity.Property(e => e.ReviewText)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Farm).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.FarmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reviews_Farm");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Reviews_User");
        });

        modelBuilder.Entity<ShoppingList>(entity =>
        {
            entity.HasKey(e => e.ListId).HasName("PK__Shopping__E38328659E5A72EB");

            entity.ToTable("ShoppingList");

            entity.Property(e => e.ListId).HasColumnName("ListID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.ShoppingLists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ShoppingList_User");
        });

        modelBuilder.Entity<ShoppingListItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Shopping__727E83EB182B8C6B");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ListId).HasColumnName("ListID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Quantity).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.List).WithMany(p => p.ShoppingListItems)
                .HasForeignKey(d => d.ListId)
                .HasConstraintName("FK_ShoppingListItems_List");

            entity.HasOne(d => d.Product).WithMany(p => p.ShoppingListItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ShoppingListItems_Product");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC1C3D57EF");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105342A65C7FB").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.IsVerified).HasDefaultValue(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

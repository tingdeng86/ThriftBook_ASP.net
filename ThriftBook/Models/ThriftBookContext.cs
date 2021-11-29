using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ThriftBook.Models
{
    public partial class ThriftBookContext : DbContext
    {
        public ThriftBookContext()
        {
        }

        public ThriftBookContext(DbContextOptions<ThriftBookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookInvoice> BookInvoices { get; set; }
        public virtual DbSet<BookRating> BookRatings { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-8CG3S52\\SQLEXPRESS;Database=ThriftBook;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.BookId)
                    .ValueGeneratedNever()
                    .HasColumnName("bookID");

                entity.Property(e => e.Author)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("author");

                entity.Property(e => e.BookPhoto)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("bookPhoto");

                entity.Property(e => e.BookQuality)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("bookQuality");

                entity.Property(e => e.BookQuantity).HasColumnName("bookQuantity");

                entity.Property(e => e.Genre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("genre");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.StoreName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("storeName");

                entity.Property(e => e.Title)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.StoreNameNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.StoreName)
                    .HasConstraintName("FK__Book__storeName__5C37ACAD");
            });

            modelBuilder.Entity<BookInvoice>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.TransactionId })
                    .HasName("PK__BookInvo__B250DDDA90BA4C14");

                entity.ToTable("BookInvoice");

                entity.Property(e => e.BookId).HasColumnName("bookID");

                entity.Property(e => e.TransactionId).HasColumnName("transactionId");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookInvoices)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookInvoi__bookI__689D8392");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.BookInvoices)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookInvoi__trans__67A95F59");
            });

            modelBuilder.Entity<BookRating>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.BuyerId })
                    .HasName("PK__BookRati__D652DB4F2D0C0FF7");

                entity.ToTable("BookRating");

                entity.Property(e => e.BookId).HasColumnName("bookID");

                entity.Property(e => e.BuyerId).HasColumnName("buyerID");

                entity.Property(e => e.BookRating1)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("bookRating");

                entity.Property(e => e.Comments)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("comments");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookRatings)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookRatin__bookI__60FC61CA");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.BookRatings)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookRatin__buyer__61F08603");
            });

            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.ToTable("Buyer");

                entity.Property(e => e.BuyerId)
                    .ValueGeneratedNever()
                    .HasColumnName("buyerID");

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("postalCode");

                entity.Property(e => e.Street)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("street");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK__Invoice__9B57CF72BD9F0531");

                entity.ToTable("Invoice");

                entity.Property(e => e.TransactionId)
                    .ValueGeneratedNever()
                    .HasColumnName("transactionId");

                entity.Property(e => e.BuyerId).HasColumnName("buyerID");

                entity.Property(e => e.DateOfTransaction)
                    .HasColumnType("date")
                    .HasColumnName("dateOfTransaction");

                entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.BuyerId)
                    .HasConstraintName("FK__Invoice__buyerID__64CCF2AE");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StoreName)
                    .HasName("PK__Store__0E3E451C32298ABE");

                entity.ToTable("Store");

                entity.Property(e => e.StoreName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("storeName");

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("postalCode");

                entity.Property(e => e.Street)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("street");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

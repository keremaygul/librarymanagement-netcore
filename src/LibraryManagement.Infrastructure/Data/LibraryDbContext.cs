using System;
using LibraryManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<BookLoan> BookLoans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Book entity'sini yapılandır
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ISBN).IsRequired();
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Author).IsRequired();
                entity.Property(e => e.Publisher).IsRequired();
                entity.Property(e => e.Category).IsRequired();
                entity.Property(e => e.Description).IsRequired();
            });

            // Member entity'sini yapılandır
            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Phone).IsRequired();
                entity.Property(e => e.Address).IsRequired();
            });

            // BookLoan entity'sini yapılandır
            modelBuilder.Entity<BookLoan>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookLoans)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.BookLoans)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Kitaplar için seed data
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    ISBN = "9789750719387",
                    Title = "İnce Memed",
                    Author = "Yaşar Kemal",
                    Publisher = "Yapı Kredi Yayınları",
                    PublicationYear = 2019,
                    Category = "Roman",
                    CopyCount = 5,
                    AvailableCopies = 5,
                    Description = "Türk edebiyatının en önemli eserlerinden biri olan İnce Memed, bir eşkıya destanı.",
                    CreatedAt = DateTime.Now
                },
                new Book
                {
                    Id = 2,
                    ISBN = "9789750738609",
                    Title = "Tutunamayanlar",
                    Author = "Oğuz Atay",
                    Publisher = "İletişim Yayınları",
                    PublicationYear = 2020,
                    Category = "Roman",
                    CopyCount = 3,
                    AvailableCopies = 3,
                    Description = "Modern Türk edebiyatının başyapıtlarından biri olarak kabul edilen Tutunamayanlar.",
                    CreatedAt = DateTime.Now
                },
                new Book
                {
                    Id = 3,
                    ISBN = "9789750726477",
                    Title = "Kürk Mantolu Madonna",
                    Author = "Sabahattin Ali",
                    Publisher = "Yapı Kredi Yayınları",
                    PublicationYear = 2018,
                    Category = "Roman",
                    CopyCount = 4,
                    AvailableCopies = 4,
                    Description = "Sabahattin Ali'nin en çok okunan romanlarından biri olan Kürk Mantolu Madonna.",
                    CreatedAt = DateTime.Now
                },
                new Book
                {
                    Id = 4,
                    ISBN = "9789750740121",
                    Title = "Şeker Portakalı",
                    Author = "Jose Mauro De Vasconcelos",
                    Publisher = "Can Yayınları",
                    PublicationYear = 2019,
                    Category = "Roman",
                    CopyCount = 6,
                    AvailableCopies = 6,
                    Description = "Brezilyalı yazar Jose Mauro de Vasconcelos'un dünya klasikleri arasına girmiş eseri.",
                    CreatedAt = DateTime.Now
                },
                new Book
                {
                    Id = 5,
                    ISBN = "9789750739859",
                    Title = "Fareler ve İnsanlar",
                    Author = "John Steinbeck",
                    Publisher = "Sel Yayıncılık",
                    PublicationYear = 2020,
                    Category = "Roman",
                    CopyCount = 4,
                    AvailableCopies = 4,
                    Description = "Nobel ödüllü yazar John Steinbeck'in en önemli eserlerinden biri.",
                    CreatedAt = DateTime.Now
                }
            );

            // Üyeler için seed data
            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    Id = 1,
                    FirstName = "Ahmet",
                    LastName = "Yılmaz",
                    Email = "ahmet.yilmaz@email.com",
                    Phone = "05301234567",
                    Address = "Kadıköy, İstanbul",
                    MembershipDate = DateTime.Now.AddMonths(-6),
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new Member
                {
                    Id = 2,
                    FirstName = "Ayşe",
                    LastName = "Demir",
                    Email = "ayse.demir@email.com",
                    Phone = "05412345678",
                    Address = "Çankaya, Ankara",
                    MembershipDate = DateTime.Now.AddMonths(-4),
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new Member
                {
                    Id = 3,
                    FirstName = "Mehmet",
                    LastName = "Kaya",
                    Email = "mehmet.kaya@email.com",
                    Phone = "05523456789",
                    Address = "Karşıyaka, İzmir",
                    MembershipDate = DateTime.Now.AddMonths(-3),
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new Member
                {
                    Id = 4,
                    FirstName = "Zeynep",
                    LastName = "Şahin",
                    Email = "zeynep.sahin@email.com",
                    Phone = "05334567890",
                    Address = "Nilüfer, Bursa",
                    MembershipDate = DateTime.Now.AddMonths(-2),
                    IsActive = true,
                    CreatedAt = DateTime.Now
                },
                new Member
                {
                    Id = 5,
                    FirstName = "Mustafa",
                    LastName = "Öztürk",
                    Email = "mustafa.ozturk@email.com",
                    Phone = "05445678901",
                    Address = "Muratpaşa, Antalya",
                    MembershipDate = DateTime.Now.AddMonths(-1),
                    IsActive = true,
                    CreatedAt = DateTime.Now
                }
            );
        }
    }
}
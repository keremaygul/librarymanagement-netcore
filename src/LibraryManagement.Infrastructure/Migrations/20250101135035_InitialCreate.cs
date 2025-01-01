using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ISBN = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Publisher = table.Column<string>(type: "TEXT", nullable: false),
                    PublicationYear = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    CopyCount = table.Column<int>(type: "INTEGER", nullable: false),
                    AvailableCopies = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    MembershipDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookLoans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    MemberId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsReturned = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExtensionCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookLoans_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookLoans_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "AvailableCopies", "Category", "CopyCount", "CreatedAt", "Description", "ISBN", "PublicationYear", "Publisher", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Yaşar Kemal", 5, "Roman", 5, new DateTime(2025, 1, 1, 16, 50, 35, 520, DateTimeKind.Local).AddTicks(9874), "Türk edebiyatının en önemli eserlerinden biri olan İnce Memed, bir eşkıya destanı.", "9789750719387", 2019, "Yapı Kredi Yayınları", "İnce Memed", null },
                    { 2, "Oğuz Atay", 3, "Roman", 3, new DateTime(2025, 1, 1, 16, 50, 35, 522, DateTimeKind.Local).AddTicks(4624), "Modern Türk edebiyatının başyapıtlarından biri olarak kabul edilen Tutunamayanlar.", "9789750738609", 2020, "İletişim Yayınları", "Tutunamayanlar", null },
                    { 3, "Sabahattin Ali", 4, "Roman", 4, new DateTime(2025, 1, 1, 16, 50, 35, 522, DateTimeKind.Local).AddTicks(4638), "Sabahattin Ali'nin en çok okunan romanlarından biri olan Kürk Mantolu Madonna.", "9789750726477", 2018, "Yapı Kredi Yayınları", "Kürk Mantolu Madonna", null },
                    { 4, "Jose Mauro De Vasconcelos", 6, "Roman", 6, new DateTime(2025, 1, 1, 16, 50, 35, 522, DateTimeKind.Local).AddTicks(4640), "Brezilyalı yazar Jose Mauro de Vasconcelos'un dünya klasikleri arasına girmiş eseri.", "9789750740121", 2019, "Can Yayınları", "Şeker Portakalı", null },
                    { 5, "John Steinbeck", 4, "Roman", 4, new DateTime(2025, 1, 1, 16, 50, 35, 522, DateTimeKind.Local).AddTicks(4642), "Nobel ödüllü yazar John Steinbeck'in en önemli eserlerinden biri.", "9789750739859", 2020, "Sel Yayıncılık", "Fareler ve İnsanlar", null }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "FirstName", "IsActive", "LastName", "MembershipDate", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Kadıköy, İstanbul", new DateTime(2025, 1, 1, 16, 50, 35, 522, DateTimeKind.Local).AddTicks(9504), "ahmet.yilmaz@email.com", "Ahmet", true, "Yılmaz", new DateTime(2024, 7, 1, 16, 50, 35, 522, DateTimeKind.Local).AddTicks(9136), "05301234567", null },
                    { 2, "Çankaya, Ankara", new DateTime(2025, 1, 1, 16, 50, 35, 522, DateTimeKind.Local).AddTicks(9513), "ayse.demir@email.com", "Ayşe", true, "Demir", new DateTime(2024, 9, 1, 16, 50, 35, 522, DateTimeKind.Local).AddTicks(9509), "05412345678", null },
                    { 3, "Karşıyaka, İzmir", new DateTime(2025, 1, 1, 16, 50, 35, 522, DateTimeKind.Local).AddTicks(9516), "mehmet.kaya@email.com", "Mehmet", true, "Kaya", new DateTime(2024, 10, 1, 16, 50, 35, 522, DateTimeKind.Local).AddTicks(9515), "05523456789", null },
                    { 4, "Nilüfer, Bursa", new DateTime(2025, 1, 1, 16, 50, 35, 522, DateTimeKind.Local).AddTicks(9518), "zeynep.sahin@email.com", "Zeynep", true, "Şahin", new DateTime(2024, 11, 1, 16, 50, 35, 522, DateTimeKind.Local).AddTicks(9517), "05334567890", null },
                    { 5, "Muratpaşa, Antalya", new DateTime(2025, 1, 1, 16, 50, 35, 522, DateTimeKind.Local).AddTicks(9520), "mustafa.ozturk@email.com", "Mustafa", true, "Öztürk", new DateTime(2024, 12, 1, 16, 50, 35, 522, DateTimeKind.Local).AddTicks(9519), "05445678901", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookLoans_BookId",
                table: "BookLoans",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLoans_MemberId",
                table: "BookLoans",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLoans");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}

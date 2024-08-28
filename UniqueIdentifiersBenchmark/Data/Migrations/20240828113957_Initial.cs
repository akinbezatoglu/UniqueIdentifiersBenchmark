using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniqueIdentifiersBenchmark.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorsAsPrimaryKeyCuid",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsAsPrimaryKeyCuid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorsAsPrimaryKeyGuid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsAsPrimaryKeyGuid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorsAsPrimaryKeyInt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsAsPrimaryKeyInt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorsAsPrimaryKeyNanoid",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsAsPrimaryKeyNanoid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorsAsPrimaryKeyUlid",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsAsPrimaryKeyUlid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorsWithCuidReferenceId",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReferenceId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsWithCuidReferenceId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorsWithGuidReferenceId",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsWithGuidReferenceId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorsWithNanoidReferenceId",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReferenceId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsWithNanoidReferenceId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorsWithUlidReferenceId",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReferenceId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsWithUlidReferenceId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BooksAsPrimaryKeyCuid",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksAsPrimaryKeyCuid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BooksAsPrimaryKeyCuid_AuthorsAsPrimaryKeyCuid_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AuthorsAsPrimaryKeyCuid",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BooksAsPrimaryKeyGuid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksAsPrimaryKeyGuid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BooksAsPrimaryKeyGuid_AuthorsAsPrimaryKeyGuid_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AuthorsAsPrimaryKeyGuid",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BooksAsPrimaryKeyInt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksAsPrimaryKeyInt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BooksAsPrimaryKeyInt_AuthorsAsPrimaryKeyInt_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AuthorsAsPrimaryKeyInt",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BooksAsPrimaryKeyNanoid",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksAsPrimaryKeyNanoid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BooksAsPrimaryKeyNanoid_AuthorsAsPrimaryKeyNanoid_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AuthorsAsPrimaryKeyNanoid",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BooksAsPrimaryKeyUlid",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksAsPrimaryKeyUlid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BooksAsPrimaryKeyUlid_AuthorsAsPrimaryKeyUlid_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AuthorsAsPrimaryKeyUlid",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BooksWithCuidReferenceId",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksWithCuidReferenceId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BooksWithCuidReferenceId_AuthorsWithCuidReferenceId_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AuthorsWithCuidReferenceId",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BooksWithGuidReferenceId",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksWithGuidReferenceId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BooksWithGuidReferenceId_AuthorsWithGuidReferenceId_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AuthorsWithGuidReferenceId",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BooksWithNanoidReferenceId",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksWithNanoidReferenceId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BooksWithNanoidReferenceId_AuthorsWithNanoidReferenceId_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AuthorsWithNanoidReferenceId",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BooksWithUlidReferenceId",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    ReferenceId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksWithUlidReferenceId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BooksWithUlidReferenceId_AuthorsWithUlidReferenceId_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AuthorsWithUlidReferenceId",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsAsPrimaryKeyCuid_Id",
                table: "AuthorsAsPrimaryKeyCuid",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsAsPrimaryKeyGuid_Id",
                table: "AuthorsAsPrimaryKeyGuid",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsAsPrimaryKeyInt_Id",
                table: "AuthorsAsPrimaryKeyInt",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsAsPrimaryKeyNanoid_Id",
                table: "AuthorsAsPrimaryKeyNanoid",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsAsPrimaryKeyUlid_Id",
                table: "AuthorsAsPrimaryKeyUlid",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsWithCuidReferenceId_Id",
                table: "AuthorsWithCuidReferenceId",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsWithCuidReferenceId_ReferenceId",
                table: "AuthorsWithCuidReferenceId",
                column: "ReferenceId",
                unique: true,
                filter: "[ReferenceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsWithGuidReferenceId_Id",
                table: "AuthorsWithGuidReferenceId",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsWithGuidReferenceId_ReferenceId",
                table: "AuthorsWithGuidReferenceId",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsWithNanoidReferenceId_Id",
                table: "AuthorsWithNanoidReferenceId",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsWithNanoidReferenceId_ReferenceId",
                table: "AuthorsWithNanoidReferenceId",
                column: "ReferenceId",
                unique: true,
                filter: "[ReferenceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsWithUlidReferenceId_Id",
                table: "AuthorsWithUlidReferenceId",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsWithUlidReferenceId_ReferenceId",
                table: "AuthorsWithUlidReferenceId",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksAsPrimaryKeyCuid_AuthorId",
                table: "BooksAsPrimaryKeyCuid",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksAsPrimaryKeyCuid_Id",
                table: "BooksAsPrimaryKeyCuid",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksAsPrimaryKeyGuid_AuthorId",
                table: "BooksAsPrimaryKeyGuid",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksAsPrimaryKeyGuid_Id",
                table: "BooksAsPrimaryKeyGuid",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksAsPrimaryKeyInt_AuthorId",
                table: "BooksAsPrimaryKeyInt",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksAsPrimaryKeyInt_Id",
                table: "BooksAsPrimaryKeyInt",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksAsPrimaryKeyNanoid_AuthorId",
                table: "BooksAsPrimaryKeyNanoid",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksAsPrimaryKeyNanoid_Id",
                table: "BooksAsPrimaryKeyNanoid",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksAsPrimaryKeyUlid_AuthorId",
                table: "BooksAsPrimaryKeyUlid",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksAsPrimaryKeyUlid_Id",
                table: "BooksAsPrimaryKeyUlid",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksWithCuidReferenceId_AuthorId",
                table: "BooksWithCuidReferenceId",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksWithCuidReferenceId_Id",
                table: "BooksWithCuidReferenceId",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksWithCuidReferenceId_ReferenceId",
                table: "BooksWithCuidReferenceId",
                column: "ReferenceId",
                unique: true,
                filter: "[ReferenceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BooksWithGuidReferenceId_AuthorId",
                table: "BooksWithGuidReferenceId",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksWithGuidReferenceId_Id",
                table: "BooksWithGuidReferenceId",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksWithGuidReferenceId_ReferenceId",
                table: "BooksWithGuidReferenceId",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksWithNanoidReferenceId_AuthorId",
                table: "BooksWithNanoidReferenceId",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksWithNanoidReferenceId_Id",
                table: "BooksWithNanoidReferenceId",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksWithNanoidReferenceId_ReferenceId",
                table: "BooksWithNanoidReferenceId",
                column: "ReferenceId",
                unique: true,
                filter: "[ReferenceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BooksWithUlidReferenceId_AuthorId",
                table: "BooksWithUlidReferenceId",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksWithUlidReferenceId_Id",
                table: "BooksWithUlidReferenceId",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksWithUlidReferenceId_ReferenceId",
                table: "BooksWithUlidReferenceId",
                column: "ReferenceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksAsPrimaryKeyCuid");

            migrationBuilder.DropTable(
                name: "BooksAsPrimaryKeyGuid");

            migrationBuilder.DropTable(
                name: "BooksAsPrimaryKeyInt");

            migrationBuilder.DropTable(
                name: "BooksAsPrimaryKeyNanoid");

            migrationBuilder.DropTable(
                name: "BooksAsPrimaryKeyUlid");

            migrationBuilder.DropTable(
                name: "BooksWithCuidReferenceId");

            migrationBuilder.DropTable(
                name: "BooksWithGuidReferenceId");

            migrationBuilder.DropTable(
                name: "BooksWithNanoidReferenceId");

            migrationBuilder.DropTable(
                name: "BooksWithUlidReferenceId");

            migrationBuilder.DropTable(
                name: "AuthorsAsPrimaryKeyCuid");

            migrationBuilder.DropTable(
                name: "AuthorsAsPrimaryKeyGuid");

            migrationBuilder.DropTable(
                name: "AuthorsAsPrimaryKeyInt");

            migrationBuilder.DropTable(
                name: "AuthorsAsPrimaryKeyNanoid");

            migrationBuilder.DropTable(
                name: "AuthorsAsPrimaryKeyUlid");

            migrationBuilder.DropTable(
                name: "AuthorsWithCuidReferenceId");

            migrationBuilder.DropTable(
                name: "AuthorsWithGuidReferenceId");

            migrationBuilder.DropTable(
                name: "AuthorsWithNanoidReferenceId");

            migrationBuilder.DropTable(
                name: "AuthorsWithUlidReferenceId");
        }
    }
}

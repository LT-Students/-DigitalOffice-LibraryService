using LT.DigitalOffice.LibraryService.DataLayer.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LT.DigitalOffice.LibraryService.DataLayer.Migrations
{
  [DbContext(typeof(LibraryServiceDbContext))]
  [Migration("20221116150000_InitialCreate")]
  public class InitialCreate : Migration
  {
    #region Create tables

    private void CreateAuthorsTable(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: DbAuthor.TableName,
        columns: table => new
        {
          Id = table.Column<Guid>(nullable: false),
          FirstName = table.Column<string>(nullable: false),
          MiddleName = table.Column<string>(nullable: true),
          LastName = table.Column<string>(nullable: false),
          IsActive = table.Column<bool>(nullable: false),
          CreatedBy = table.Column<Guid>(nullable: false),
          CreatedAtUtc = table.Column<DateTime>(nullable: false),
          ModifiedBy = table.Column<Guid>(nullable: true),
          ModifiedAtUtc = table.Column<DateTime>(nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Authors", x => x.Id);
        });
    }

    private void CreateBooksTable(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: DbBook.TableName,
        columns: table => new
        {
          Id = table.Column<Guid>(nullable: false),
          Name = table.Column<string>(nullable: false),
          AuthorId = table.Column<Guid>(nullable: false),
          CategoryId = table.Column<Guid>(nullable: false),
          Description = table.Column<string>(nullable: false),
          IsActive = table.Column<bool>(nullable: false),
          CreatedBy = table.Column<Guid>(nullable: false),
          CreatedAtUtc = table.Column<DateTime>(nullable: false),
          ModifiedBy = table.Column<Guid>(nullable: true),
          ModifiedAtUtc = table.Column<DateTime>(nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Books", x => x.Id);
        });
    }

    private void CreateReviewsTable(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: DbReview.TableName,
        columns: table => new
        {
          Id = table.Column<Guid>(nullable: false),
          UserId = table.Column<Guid>(nullable: false),
          BookId = table.Column<Guid>(nullable: false),
          Content = table.Column<string>(nullable: false),
          IsActive = table.Column<bool>(nullable: false),
          CreatedAtUtc = table.Column<DateTime>(nullable: false),
          ModifiedAtUtc = table.Column<DateTime>(nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Reviews", x => x.Id);
        });
    }

    private void CreateCategoriesTable(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: DbCategory.TableName,
        columns: table => new
        {
          Id = table.Column<Guid>(nullable: false),
          Name = table.Column<string>(nullable: false),
          CreatedBy = table.Column<Guid>(nullable: false),
          CreatedAtUtc = table.Column<DateTime>(nullable: false),
          ModifiedBy = table.Column<Guid>(nullable: true),
          ModifiedAtUtc = table.Column<DateTime>(nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Categories", x => x.Id);
        });
    }

    private void CreateBooksCategoriesTable(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: DbBookCategory.TableName,
        columns: table => new
        {
          Id = table.Column<Guid>(nullable: false),
          BookId = table.Column<Guid>(nullable: false),
          CategoryId = table.Column<Guid>(nullable: false),
          CreatedBy = table.Column<Guid>(nullable: false),
          CreatedAtUtc = table.Column<DateTime>(nullable: false),
          ModifiedBy = table.Column<Guid>(nullable: true),
          ModifiedAtUtc = table.Column<DateTime>(nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_BooksCategories", x => x.Id);
        });
    }

    private void CreateBooksFilesTable(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: DbBookFile.TableName,
        columns: table => new
        {
          Id = table.Column<Guid>(nullable: false),
          BookId = table.Column<Guid>(nullable: false),
          FileId = table.Column<Guid>(nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_BooksFiles", x => x.Id);
        });
    }

    #endregion

    protected override void Up(MigrationBuilder migrationBuilder)
    {
      CreateAuthorsTable(migrationBuilder);

      CreateBooksTable(migrationBuilder);

      CreateReviewsTable(migrationBuilder);

      CreateCategoriesTable(migrationBuilder);
      CreateBooksCategoriesTable(migrationBuilder);

      CreateBooksFilesTable(migrationBuilder);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(DbAuthor.TableName);

      migrationBuilder.DropTable(DbBook.TableName);

      migrationBuilder.DropTable(DbReview.TableName);

      migrationBuilder.DropTable(DbCategory.TableName);
      migrationBuilder.DropTable(DbBookCategory.TableName);

      migrationBuilder.DropTable(DbBookFile.TableName);
    }
  }
}

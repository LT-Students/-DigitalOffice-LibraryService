using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LT.DigitalOffice.LibraryService.DataLayer.Models
{
  public class DbBookCategory
  {
    public const string TableName = "BooksCategories";

    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedAtUtc { get; set; }

    public DbBook Book { get; set; }
    public DbCategory Category { get; set; }

    public class DbBookCategoryConfiguration : IEntityTypeConfiguration<DbBookCategory>
    {
      public void Configure(EntityTypeBuilder<DbBookCategory> builder)
      {
        builder
          .ToTable(DbBookCategory.TableName);

        builder
          .HasKey(bc => bc.Id);

        builder
          .HasOne(b => b.Book)
          .WithMany(bc => bc.Categories);

        builder
          .HasOne(c => c.Category)
          .WithMany(bc => bc.Books);
      }
    }
  }
}

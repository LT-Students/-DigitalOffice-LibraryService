using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LT.DigitalOffice.LibraryService.DataLayer.Models
{
  public class DbBookFile
  {
    public const string TableName = "BooksFiles";

    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public Guid FileId { get; set; }
    public bool IsActive { get; set; }

    public DbBook Book { get; set; }

    public class DbBookFileConfiguration : IEntityTypeConfiguration<DbBookFile>
    {
      public void Configure(EntityTypeBuilder<DbBookFile> builder)
      {
        builder
          .ToTable(DbBookFile.TableName);

        builder
          .HasKey(bf => bf.Id);

        builder
          .HasOne(bf => bf.Book)
          .WithMany(b => b.Files);
      }
    }
  }
}

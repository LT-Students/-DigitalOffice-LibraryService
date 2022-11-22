using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.LibraryService.DataLayer.Models
{
  public class DbBook
  {
    public const string TableName = "Books";

    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid AuthorId { get; set; }
    public string Description { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedAtUtc { get; set; }

    public DbAuthor Author { get; set; }
    public ICollection<DbReview> Reviews { get; set; }
    public ICollection<DbBookCategory> Categories { get; set; }
    public ICollection<DbBookFile> Files { get; set; }

    public DbBook()
    {
      Reviews = new HashSet<DbReview>();
      Files = new HashSet<DbBookFile>();
      Categories = new HashSet<DbBookCategory>();
    }
  }
  public class DbBookConfiguration : IEntityTypeConfiguration<DbBook>
  {
    public void Configure(EntityTypeBuilder<DbBook> builder)
    {
      builder
        .ToTable(DbBook.TableName);

      builder
        .Property(b => b.Name)
        .IsRequired();

      builder
        .HasKey(b => b.Id);

      builder
        .HasOne(b => b.Author)
        .WithMany(a => a.Books);

      builder
        .HasMany(b => b.Reviews)
        .WithOne(r => r.Book);

      builder
        .HasMany(b => b.Categories)
        .WithOne(bc => bc.Book);

      builder
        .HasMany(b => b.Files)
        .WithOne(bf => bf.Book);
    }
  }
}

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
    public Guid CategoryId { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
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
          .Property(a => a.Name)
          .IsRequired();

      builder
          .Property(a => a.Description)
          .IsRequired();

      builder
        .HasKey(b => b.Id);

      builder
        .HasOne(a => a.Author)
        .WithMany(b => b.Books);

      builder
        .HasMany(r => r.Reviews)
        .WithOne(b => b.Book);

      builder
        .HasMany(u => u.Categories)
        .WithOne(u => u.Book);

      builder
        .HasMany(u => u.Files)
        .WithOne(u => u.Book);
    }
  }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.LibraryService.DataLayer.Models
{
  public class DbAuthor
  {
    public const string TableName = "Authors";

    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedAtUtc { get; set; }

    public ICollection<DbBook> Books { get; set; }

    public DbAuthor()
    {
      Books = new HashSet<DbBook>();
    }

    public class DbAuthorConfiguration : IEntityTypeConfiguration<DbAuthor>
    {
      public void Configure(EntityTypeBuilder<DbAuthor> builder)
      {
        builder
          .ToTable(DbAuthor.TableName);

        builder
          .HasKey(a => a.Id);

        builder
          .Property(a => a.LastName)
          .IsRequired();

        builder
          .HasMany(a => a.Books)
          .WithOne(b => b.Author);
      }
    }

  }
}

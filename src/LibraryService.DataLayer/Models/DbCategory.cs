using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace LT.DigitalOffice.LibraryService.DataLayer.Models
{
  public class DbCategory
  {
    public const string TableName = "Categories";

    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedAtUtc { get; set; }

    public ICollection<DbBookCategory> Books { get; set; }

    public DbCategory()
    {
      Books = new HashSet<DbBookCategory>();
    }

    public class DbCategoryConfiguration : IEntityTypeConfiguration<DbCategory>
    {
      public void Configure(EntityTypeBuilder<DbCategory> builder)
      {
        builder
          .ToTable(DbCategory.TableName);

        builder
          .HasKey(c => c.Id);

        builder
          .Property(c => c.Name)
          .IsRequired();

        builder
          .HasMany(c => c.Books)
          .WithOne(b => b.Category);
      }
    }
  }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LT.DigitalOffice.LibraryService.DataLayer.Models
{
  public class DbReview
  {
    public const string TableName = "Reviews";

    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public string Content { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? ModifiedAtUtc { get; set; }

    public DbBook Book { get; set; }

    public class DbReviewConfiguration : IEntityTypeConfiguration<DbReview>
    {
      public void Configure(EntityTypeBuilder<DbReview> builder)
      {
        builder
          .ToTable(DbReview.TableName);

        builder
          .Property(r => r.Content)
          .IsRequired();

        builder
          .HasKey(r => r.Id);

        builder
          .HasOne(b => b.Book)
          .WithMany(r => r.Reviews);
      }
    }
  }
}

using LT.DigitalOffice.LibraryService.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading.Tasks;

namespace LT.DigitalOffice.LibraryService.DataLayer
{
  public class LibraryServiceDbContext :DbContext
  {
    public DbSet<DbAuthor> Authors { get; set; }
    public DbSet<DbBook> Books { get; set; }
    public DbSet<DbCategory> Categories { get; set; }
    public DbSet<DbReview> Reviews { get; set; }
    public DbSet<DbBookCategory> BooksCategories { get; set; }
    public DbSet<DbBookFile> DbBooksFiles { get; set; }

    public LibraryServiceDbContext(DbContextOptions<LibraryServiceDbContext> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("LT.DigitalOffice.LibraryService.DataLayer"));
    }

    public object MakeEntityDetached(object obj)
    {
      Entry(obj).State = EntityState.Detached;

      return Entry(obj).State;
    }

    public void Save()
    {
      SaveChanges();
    }

    public void EnsureDeleted()
    {
      Database.EnsureDeleted();
    }

    public bool IsInMemory()
    {
      return Database.IsInMemory();
    }

    public async Task SaveAsync()
    {
      await SaveChangesAsync();
    }
  }
}

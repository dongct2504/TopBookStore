using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TopBookStore.Infrastructure.Identity;

namespace TopBookStore.Infrastructure.Identity;

public class IdentityTopBookStoreDbContext : IdentityDbContext<IdentityTopBookStoreUser>
{
    protected IdentityTopBookStoreDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public IdentityTopBookStoreDbContext(DbContextOptions<IdentityTopBookStoreDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}

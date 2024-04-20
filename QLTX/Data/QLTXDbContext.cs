using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QLTX.Models;

namespace QLTX.Data;

public class QLTXDbContext : IdentityDbContext<User>
{
    public QLTXDbContext(DbContextOptions<QLTXDbContext> options) : base(options)
    {

    }
    public DbSet<QLTX.Models.Company> Company { get; set; } = default!;
    public DbSet<QLTX.Models.EMotorbike> EMotorbike { get; set; } = default!;

}

using System.Diagnostics;
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
    public DbSet<Company> Companies { get; set; } = default!;
	public DbSet<TypeMotorbike> TypeMotorbikes { get; set; } = default!;
    public DbSet<EMotorbike> EMotorbikes { get; set; } = default!;
	public DbSet<User> Users {  get; set; } = default!;
	public DbSet<Rental> Rentals { get; set; } = default!;
	public DbSet<RentalDetail> RentalDetails { get; set; } = default!;
	public DbSet<Customer> Customers { get; set; } = default!;
	public DbSet<Bill> Bills { get; set; } = default!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<TypeMotorbike>()
			.HasOne<Company>(s => s.Company)
			.WithMany(g => g.TypeMotorbikes)
			.HasForeignKey(s => s.CompanyId);

		modelBuilder.Entity<EMotorbike>()
			.HasOne<TypeMotorbike>(s => s.TypeMotorbike)
			.WithMany(g => g.EMotorbikes)
			.HasForeignKey(s => s.TypeMotorbikeId);

		modelBuilder.Entity<RentalDetail>()
		.HasKey(rd => new { rd.EMotorbileId, rd.RentalId });

		// Quan hệ n-n giữa EMotorbike và Rental
		modelBuilder.Entity<RentalDetail>()
			.HasOne(rd => rd.EMotorbike)
			.WithMany()
			.HasForeignKey(rd => rd.EMotorbileId);

		modelBuilder.Entity<RentalDetail>()
			.HasOne(rd => rd.Rental)
			.WithMany()
			.HasForeignKey(rd => rd.RentalId);
		modelBuilder.Entity<IdentityUserLogin<string>>()
		.HasKey(l => l.UserId);
		modelBuilder.Entity<IdentityUserRole<string>>()
		.HasKey(ur => new { ur.UserId, ur.RoleId });
		modelBuilder.Entity<IdentityUserToken<string>>()
		.HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });
		modelBuilder.Entity<Rental>()
		.HasOne(r => r.User)
		.WithMany(u => u.Rentals)
		.HasForeignKey(r => r.UserId);
	}
}

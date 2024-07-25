using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QLTX.Models;

namespace QLTX.Data;

public class QLTXDbContext : IdentityDbContext<User, Role, string,
		IdentityUserClaim<string>, UserRoles, IdentityUserLogin<string>,
		IdentityRoleClaim<string>, IdentityUserToken<string>>
{
	public QLTXDbContext(DbContextOptions<QLTXDbContext> options) : base(options)
	{

	}
	public DbSet<Company> Companies { get; set; } = default!;
	public DbSet<TypeMotorbike> TypeMotorbikes { get; set; } = default!;
	public DbSet<EMotorbike> EMotorbikes { get; set; } = default!;
	//public DbSet<User> Users { get; set; } = default!;
	public DbSet<Rental> Rentals { get; set; } = default!;
	public DbSet<RentalDetail> RentalDetails { get; set; } = default!;
	public DbSet<Customer> Customers { get; set; } = default!;
	public DbSet<Store> Stores { get; set; } = default!;
	//public DbSet<Role> Roles { get; set; } = default!;
	//public DbSet<UserRoles> UserRoles { get; set; } = default!;


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<TypeMotorbike>()
			.HasOne<Company>(s => s.Company)
			.WithMany(g => g.TypeMotorbikes)
			.HasForeignKey(s => s.CompanyId);

		modelBuilder.Entity<EMotorbike>()
			.HasOne<TypeMotorbike>(s => s.TypeMotorbike)
			.WithMany(g => g.EMotorbikes)
			.HasForeignKey(s => s.TypeMotorbikeId)
			
			;

        modelBuilder.Entity<EMotorbike>(b =>
        {
            b.HasOne(s => s.TypeMotorbike)
             .WithMany(g => g.EMotorbikes)
             .HasForeignKey(s => s.TypeMotorbikeId);

            b.HasMany(e => e.RentlDetails)
             .WithOne(e => e.EMotorbike)
             .HasForeignKey(ur => ur.EMotorbileId);
        });

        // Cấu hình cho Rental
        modelBuilder.Entity<Rental>(b =>
        {
            b.HasMany(e => e.RentlDetails)
             .WithOne(e => e.Rental)
             .HasForeignKey(ur => ur.RentalId);
        });

		modelBuilder.Entity<RentalDetail>(b =>
		{
			b.HasKey(rd => new { rd.RentalId, rd.EMotorbileId });

			b.HasOne(rd => rd.Rental)
			 .WithMany(r => r.RentlDetails)
			 .HasForeignKey(rd => rd.RentalId);

			b.HasOne(rd => rd.EMotorbike)
			 .WithMany(e => e.RentlDetails)
			 .HasForeignKey(rd => rd.EMotorbileId);
		});
		//modelBuilder.Entity<RentalDetail>()
		//.HasKey(rd => new { rd.EMotorbileId, rd.RentalId });

		//      modelBuilder.Entity<RentalDetail>()
		//          .HasOne(rd => rd.Rental)
		//          .WithMany(r => r.RentlDetails)
		//          .HasForeignKey(rd => rd.RentalId);

		//      modelBuilder.Entity<RentalDetail>()
		//          .HasOne(rd => rd.EMotorbike)
		//          .WithMany()
		//          .HasForeignKey(rd => rd.EMotorbileId);

		/*modelBuilder.Entity<RentalDetail>()
			.HasOne(rd => rd.EMotorbike)
			.WithMany()
			.HasForeignKey(rd => rd.EMotorbileId);

		modelBuilder.Entity<RentalDetail>()
			.HasOne(rd => rd.Rental)
			.WithMany()
			.HasForeignKey(rd => rd.RentalId);*/
		modelBuilder.Entity<User>(b =>
		{
			b.ToTable("Users");
			b.HasMany(e => e.Claims)
				.WithOne()
				.HasForeignKey(uc => uc.UserId)
				.IsRequired(); 

			b.HasMany(e => e.Logins)
				.WithOne()
				.HasForeignKey(ul => ul.UserId)
				.IsRequired(); 

			b.HasMany(e => e.Tokens)
				.WithOne()
				.HasForeignKey(ut => ut.UserId)
				.IsRequired();

			b.HasMany(e => e.UserRoles)
				.WithOne(e => e.User)
				.HasForeignKey(ur => ur.UserId);
				/*.IsRequired()*/
		});

		modelBuilder.Entity<Role>(b =>
		{
			b.ToTable("Roles");
			b.HasMany(e => e.UserRoles)
				.WithOne(e => e.Role)
				.HasForeignKey(ur => ur.RoleId)
				.IsRequired();
		});

		modelBuilder.Entity<IdentityUserClaim<string>>(b =>
		{
			b.ToTable("UserClaims");
		});

		modelBuilder.Entity<IdentityUserLogin<string>>(b =>
		{
			b.ToTable("UserLogins");
			b.HasKey(login => new { login.LoginProvider, login.ProviderKey });
		});

		modelBuilder.Entity<IdentityUserToken<string>>(b =>
		{
			b.ToTable("UserTokens");
		});

		modelBuilder.Entity<IdentityRoleClaim<string>>(b =>
		{
			b.ToTable("RoleClaims");
		});

		modelBuilder.Entity<UserRoles>(b =>
		{
			b.ToTable("UserRoles");
		});

		modelBuilder.Entity<IdentityUserLogin<string>>()
			.HasKey(login => new { login.LoginProvider, login.ProviderKey });
	}
}


﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLTX.Migrations
{
    /// <inheritdoc />
    public partial class colume_f : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Companies",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UpdationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Companies", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Customers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        TypeDocument = table.Column<int>(type: "int", nullable: false),
            //        IdDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UpdationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Customers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Roles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UpdationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Roles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UpdationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TypeMotorbikes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Power = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Speed = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Battery = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Charging = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CompanyId = table.Column<int>(type: "int", nullable: false),
            //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UpdationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TypeMotorbikes", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_TypeMotorbikes_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_RoleClaims_Roles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "Roles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Rentals",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CustomerId = table.Column<int>(type: "int", nullable: false),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        DateRetalFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        DateRetalTo = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        RetalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Service = table.Column<int>(type: "int", nullable: false),
            //        Price = table.Column<double>(type: "float", nullable: false),
            //        Status = table.Column<int>(type: "int", nullable: false),
            //        Total = table.Column<double>(type: "float", nullable: false),
            //        Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UpdationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Rentals", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Rentals_Customers_CustomerId",
            //            column: x => x.CustomerId,
            //            principalTable: "Customers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Rentals_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UserClaims_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_UserLogins_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_UserRoles_Roles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "Roles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UserRoles_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_UserTokens_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "EMotorbikes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        TypeMotorbikeId = table.Column<int>(type: "int", nullable: false),
            //        VinNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        License = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Status = table.Column<int>(type: "int", nullable: false),
            //        ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UpdationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EMotorbikes", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_EMotorbikes_TypeMotorbikes_TypeMotorbikeId",
            //            column: x => x.TypeMotorbikeId,
            //            principalTable: "TypeMotorbikes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Bills",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        RentalId = table.Column<int>(type: "int", nullable: false),
            //        Status = table.Column<bool>(type: "bit", nullable: false),
            //        DatePay = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        SumEMotor = table.Column<int>(type: "int", nullable: false),
            //        SumAmount = table.Column<double>(type: "float", nullable: false),
            //        CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UpdationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Bills", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Bills_Rentals_RentalId",
            //            column: x => x.RentalId,
            //            principalTable: "Rentals",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
                ////name: "RentalDetails",
                //columns: table => new
                //{
                //    EMotorbileId = table.Column<int>(type: "int", nullable: false),
                //    RentalId = table.Column<int>(type: "int", nullable: false),
                //    RentalId1 = table.Column<int>(type: "int", nullable: true)
                //},
                //constraints: table =>
                //{
                //    table.PrimaryKey("PK_RentalDetails", x => new { x.EMotorbileId, x.RentalId });
                //    table.ForeignKey(
                //        name: "FK_RentalDetails_EMotorbikes_EMotorbileId",
                //        column: x => x.EMotorbileId,
                //        principalTable: "EMotorbikes",
                //        principalColumn: "Id",
                //        onDelete: ReferentialAction.Cascade);
                //    table.ForeignKey(
                //        name: "FK_RentalDetails_Rentals_RentalId",
                //        column: x => x.RentalId,
                //        principalTable: "Rentals",
                //        principalColumn: "Id",
                //        onDelete: ReferentialAction.Cascade);
                //    table.ForeignKey(
                //        name: "FK_RentalDetails_Rentals_RentalId1",
                //        column: x => x.RentalId1,
                //        principalTable: "Rentals",
                //        principalColumn: "Id");
                //});

            //migrationBuilder.CreateIndex(
            //    name: "IX_Bills_RentalId",
            //    table: "Bills",
            //    column: "RentalId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_EMotorbikes_TypeMotorbikeId",
            //    table: "EMotorbikes",
            //    column: "TypeMotorbikeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RentalDetails_RentalId",
            //    table: "RentalDetails",
            //    column: "RentalId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RentalDetails_RentalId1",
            //    table: "RentalDetails",
            //    column: "RentalId1");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Rentals_CustomerId",
            //    table: "Rentals",
            //    column: "CustomerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Rentals_UserId",
            //    table: "Rentals",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RoleClaims_RoleId",
            //    table: "RoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "Roles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TypeMotorbikes_CompanyId",
            //    table: "TypeMotorbikes",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserClaims_UserId",
            //    table: "UserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserLogins_UserId",
            //    table: "UserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserRoles_RoleId",
            //    table: "UserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "Users",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "Users",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Bills");

            //migrationBuilder.DropTable(
            //    name: "RentalDetails");

            //migrationBuilder.DropTable(
            //    name: "RoleClaims");

            //migrationBuilder.DropTable(
            //    name: "UserClaims");

            //migrationBuilder.DropTable(
            //    name: "UserLogins");

            //migrationBuilder.DropTable(
            //    name: "UserRoles");

            //migrationBuilder.DropTable(
            //    name: "UserTokens");

            //migrationBuilder.DropTable(
            //    name: "EMotorbikes");

            //migrationBuilder.DropTable(
            //    name: "Rentals");

            //migrationBuilder.DropTable(
            //    name: "Roles");

            //migrationBuilder.DropTable(
            //    name: "TypeMotorbikes");

            //migrationBuilder.DropTable(
            //    name: "Customers");

            //migrationBuilder.DropTable(
            //    name: "Users");

            //migrationBuilder.DropTable(
            //    name: "Companies");
        }
    }
}

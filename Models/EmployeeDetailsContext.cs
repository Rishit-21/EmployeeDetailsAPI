using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EmployeeDetailsAPI.Models
{
    public partial class EmployeeDetailsContext : DbContext
    {
        public EmployeeDetailsContext()
        {
        }

        public EmployeeDetailsContext(DbContextOptions<EmployeeDetailsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        //public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        //public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<EmpCityTbl> EmpCityTbls { get; set; }
        public virtual DbSet<EmpCountryTbl> EmpCountryTbls { get; set; }
        public virtual DbSet<EmpStateTbl> EmpStateTbls { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<UsersLog> UsersLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-DGENJK4\\SQLEXPRESS;DataBase=EmployeeDetails;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.CurrAddressId)
                    .HasName("PK__Address__CAF6859E49652A77");

                entity.ToTable("Address");

                entity.Property(e => e.AddType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CurrAddressDetails)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__Address__CityId__00200768");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Address__Country__4316F928");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__Address__empId__7D439ABD");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__Address__StateId__7F2BE32F");
            });

            //modelBuilder.Entity<AspNetRole>(entity =>
            //{
            //    entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedName] IS NOT NULL)");

            //    entity.Property(e => e.Name).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetRoleClaim>(entity =>
            //{
            //    entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            //    entity.Property(e => e.RoleId).IsRequired();

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetRoleClaims)
            //        .HasForeignKey(d => d.RoleId);
            //});

            //modelBuilder.Entity<AspNetUser>(entity =>
            //{
            //    entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            //    entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedUserName] IS NOT NULL)");

            //    entity.Property(e => e.Email).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            //    entity.Property(e => e.UserName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetUserClaim>(entity =>
            //{
            //    entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            //    entity.Property(e => e.UserId).IsRequired();

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserClaims)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserLogin>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            //    entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            //    entity.Property(e => e.UserId).IsRequired();

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserLogins)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserRole>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.RoleId });

            //    entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.RoleId);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserToken>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserTokens)
            //        .HasForeignKey(d => d.UserId);
            //});

            modelBuilder.Entity<EmpCityTbl>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK__EmpCityT__F2D21B766FC4B4AC");

                entity.ToTable("EmpCityTbl");

                entity.HasIndex(e => e.CityName, "UQ__EmpCityT__886159E5CCEF1AE0")
                    .IsUnique();

                entity.Property(e => e.CityName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.EmpCityTbls)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__EmpCityTb__State__2C3393D0");
            });

            modelBuilder.Entity<EmpCountryTbl>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PK__EmpCount__10D160BF906CEAA9");

                entity.ToTable("EmpCountryTbl");

                entity.HasIndex(e => e.CountryName, "UQ__EmpCount__E056F2015DB0653C")
                    .IsUnique();

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmpStateTbl>(entity =>
            {
                entity.HasKey(e => e.StateId)
                    .HasName("PK__EmpState__C3BA3B3AB7299FEB");

                entity.ToTable("EmpStateTbl");

                entity.HasIndex(e => e.StateName, "UQ__EmpState__55476315EFF893FA")
                    .IsUnique();

                entity.Property(e => e.StateName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.EmpStateTbls)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__EmpStateT__Count__286302EC");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__employee__AFB3EC0D74B94C4D");

                entity.ToTable("employee");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsersLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__UsersLog__7839F64D8BE74B54");

                entity.ToTable("UsersLog");

                entity.Property(e => e.LogId).HasColumnName("logId");

                entity.Property(e => e.Actions)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("actions");

                

               

                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .HasColumnName("userId");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                

                //entity.HasOne(d => d.User)
                //    .WithMany(p => p.UsersLogs)
                //    .HasForeignKey(d => d.UserId)
                //    .HasConstraintName("FK__UsersLog__userId__6EF57B66");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

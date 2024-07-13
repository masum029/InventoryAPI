using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RepoPatternAPI.Models
{
    //public class InventoryContext : DbContext
    public class InventoryContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<SubMenu> SubMenus { get; set; }

        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);

            modelBuilder.Entity<MenuRole>()
                .HasKey(mr => new { mr.MenuId, mr.RoleId });

            modelBuilder.Entity<MenuRole>()
                .HasOne(mr => mr.Menu)
                .WithMany(m => m.MenuRoles)
                .HasForeignKey(mr => mr.MenuId);

            modelBuilder.Entity<MenuRole>()
                .HasOne(mr => mr.Role)
                .WithMany()
                .HasForeignKey(mr => mr.RoleId);

            modelBuilder.Entity<SubMenuRole>()
                .HasKey(smr => new { smr.SubMenuId, smr.RoleId });

            modelBuilder.Entity<SubMenuRole>()
                .HasOne(smr => smr.SubMenu)
                .WithMany(sm => sm.SubMenuRoles)
                .HasForeignKey(smr => smr.SubMenuId);

            modelBuilder.Entity<SubMenuRole>()
                .HasOne(smr => smr.Role)
                .WithMany()
                .HasForeignKey(smr => smr.RoleId);
        }
    }

    //public class InventoryContextbkp : IdentityDbContext<ApplicationUser,ApplicationRole,string>
    //{
    //    public InventoryContextbkp(DbContextOptions<InventoryContextbkp> options):base(options) { }
        
    //    public DbSet<Company> Companies { get; set; }
    //    public DbSet<Warehouse> Warehouses { get; set; }
    //    public DbSet<Product> Products { get; set; }
    //    public DbSet<Category> Categories { get; set; }
    //    public DbSet<Order> Orders { get; set; }
    //    public DbSet<OrderProduct> OrderProducts { get; set; }
    //    public DbSet<Menu> Menus { get; set; }
    //    public DbSet<SubMenu> SubMenus { get; set; }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);

    //        modelBuilder.Entity<OrderProduct>()
    //            .HasKey(op => new { op.OrderId, op.ProductId });

    //        modelBuilder.Entity<OrderProduct>()
    //            .HasOne(op => op.Order)
    //            .WithMany(o => o.OrderProducts)
    //            .HasForeignKey(op => op.OrderId);

    //        modelBuilder.Entity<OrderProduct>()
    //            .HasOne(op => op.Product)
    //            .WithMany(p => p.OrderProducts)
    //            .HasForeignKey(op => op.ProductId);

    //        modelBuilder.Entity<MenuRole>()
    //        .HasKey(mr => new { mr.MenuId, mr.RoleId });

    //        modelBuilder.Entity<SubMenuRole>()
    //            .HasKey(smr => new { smr.SubMenuId, smr.RoleId });

    //    }
    //}

}

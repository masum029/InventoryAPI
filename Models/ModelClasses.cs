namespace RepoPatternAPI.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }
        public string? Name { get; set; }
        public Warehouse? Warehouse { get; set; }
    }

    public class Warehouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WarehouseId { get; set; }
        public string? Location { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public ICollection<Product>? Products { get; set; }
    }

    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public int? WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }

    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }

    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }

    public class OrderProduct
    {
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
    }

    public class ApplicationUser : IdentityUser
    {
        // Additional properties can be added here
    }

    public class ApplicationRole : IdentityRole
    {
        //public ICollection<MenuRole> RoleMenus { get; set; }
    }

    public class RegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string? Url { get; set; }
        public ICollection<SubMenu>? SubMenus { get; set; }
        public ICollection<MenuRole>? MenuRoles { get; set; }
    }

    public class SubMenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubMenuId { get; set; }
        public string Name { get; set; }
        public string? Url { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public ICollection<SubMenuRole>? SubMenuRoles { get; set; }
    }

    public class MenuRole
    {
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public string? RoleId { get; set; }
        public ApplicationRole? Role { get; set; }
    }

    public class SubMenuRole
    {
        public int SubMenuId { get; set; }
        public SubMenu SubMenu { get; set; }
        public string? RoleId { get; set; }
        public ApplicationRole? Role { get; set; }
    }

}

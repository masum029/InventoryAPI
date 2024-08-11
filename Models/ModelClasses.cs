namespace RepoPatternAPI.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    #region New Model Inventory
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }
        public string? Name { get; set; }
        public string? FullName { get; set; }
        public string? ContactPerson { get; set; }
        public string? Address { get; set; }
        public string? PhoneNo { get; set; }
        public string? FaxNo { get; set; }
        public string? EmailNo { get; set; }
        public bool IsActive { get; set; }
        public Warehouse? Warehouse { get; set; }
    }

    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(255, ErrorMessage = "Category name cannot be longer than 255 characters.")]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public int? ParentCategoryID { get; set; }

        [ForeignKey("ParentCategoryID")]
        public Category? ParentCategory { get; set; }

        public ICollection<Category>? SubCategories { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }

        [Required(ErrorMessage = "Supplier name is required.")]
        [StringLength(255, ErrorMessage = "Supplier name cannot be longer than 255 characters.")]
        public string SupplierName { get; set; }

        [StringLength(255, ErrorMessage = "Contact name cannot be longer than 255 characters.")]
        public string ContactName { get; set; }

        [StringLength(255, ErrorMessage = "Contact title cannot be longer than 255 characters.")]
        public string ContactTitle { get; set; }

        [StringLength(255, ErrorMessage = "Address cannot be longer than 255 characters.")]
        public string Address { get; set; }

        [StringLength(255, ErrorMessage = "City cannot be longer than 255 characters.")]
        public string City { get; set; }

        [StringLength(255, ErrorMessage = "Region cannot be longer than 255 characters.")]
        public string Region { get; set; }

        [StringLength(255, ErrorMessage = "Postal code cannot be longer than 255 characters.")]
        public string PostalCode { get; set; }

        [StringLength(255, ErrorMessage = "Country cannot be longer than 255 characters.")]
        public string Country { get; set; }

        [StringLength(255, ErrorMessage = "Phone number cannot be longer than 255 characters.")]
        public string Phone { get; set; }

        [StringLength(255, ErrorMessage = "Fax number cannot be longer than 255 characters.")]
        public string Fax { get; set; }

        public string HomePage { get; set; }

        public ICollection<Product> Products { get; set; }
    }
    public class Warehouse
    {
        [Key]
        public int WarehouseID { get; set; }

        [Required(ErrorMessage = "Warehouse name is required.")]
        [StringLength(255, ErrorMessage = "Warehouse name cannot be longer than 255 characters.")]
        public string WarehouseName { get; set; }

        [StringLength(255, ErrorMessage = "Location cannot be longer than 255 characters.")]
        public string Location { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }

    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(255, ErrorMessage = "Product name cannot be longer than 255 characters.")]
        public string ProductName { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

        [Required(ErrorMessage = "Supplier ID is required.")]
        public int SupplierID { get; set; }

        [ForeignKey("SupplierID")]
        public Supplier Supplier { get; set; }

        [StringLength(50, ErrorMessage = "Quantity per unit cannot be longer than 50 characters.")]
        public string QuantityPerUnit { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Unit price must be a non-negative value.")]
        public decimal UnitPrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Units in stock must be a non-negative value.")]
        public int UnitsInStock { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Reorder level must be a non-negative value.")]
        public int ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        [StringLength(255, ErrorMessage = "Batch number cannot be longer than 255 characters.")]
        public string BatchNumber { get; set; }

        public DateTime? ExpirationDate { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string ImageURL { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Weight must be a non-negative value.")]
        public decimal Weight { get; set; }

        [StringLength(255, ErrorMessage = "Dimensions cannot be longer than 255 characters.")]
        public string Dimensions { get; set; }
    }
    public class Stock
    {
        [Key]
        public int StockID { get; set; }

        [Required(ErrorMessage = "Product ID is required.")]
        public int ProductID { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        [Required(ErrorMessage = "Warehouse ID is required.")]
        public int WarehouseID { get; set; }

        [ForeignKey("WarehouseID")]
        public Warehouse Warehouse { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative value.")]
        public int Quantity { get; set; }
    }

    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(255, ErrorMessage = "Customer name cannot be longer than 255 characters.")]
        public string CustomerName { get; set; }

        [StringLength(255, ErrorMessage = "Contact name cannot be longer than 255 characters.")]
        public string ContactName { get; set; }

        [StringLength(255, ErrorMessage = "Contact title cannot be longer than 255 characters.")]
        public string ContactTitle { get; set; }

        [StringLength(255, ErrorMessage = "Address cannot be longer than 255 characters.")]
        public string Address { get; set; }

        [StringLength(255, ErrorMessage = "City cannot be longer than 255 characters.")]
        public string City { get; set; }

        [StringLength(255, ErrorMessage = "Region cannot be longer than 255 characters.")]
        public string Region { get; set; }

        [StringLength(255, ErrorMessage = "Postal code cannot be longer than 255 characters.")]
        public string PostalCode { get; set; }

        [StringLength(255, ErrorMessage = "Country cannot be longer than 255 characters.")]
        public string Country { get; set; }

        [StringLength(255, ErrorMessage = "Phone number cannot be longer than 255 characters.")]
        public string Phone { get; set; }

        [StringLength(255, ErrorMessage = "Fax number cannot be longer than 255 characters.")]
        public string Fax { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(255, ErrorMessage = "Email cannot be longer than 255 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(255, ErrorMessage = "Password hash cannot be longer than 255 characters.")]
        public string PasswordHash { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string MedicalHistory { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }

    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }
        public string PhotoPath { get; set; }
        public Employee Manager { get; set; }
        public ICollection<Employee> Subordinates { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
    public class Shipper
    {
        [Key]
        public int ShipperID { get; set; }
        [Required]
        public string ShipperName { get; set; }
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
    public class Prescription
    {
        [Key]
        public int PrescriptionID { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public string DoctorName { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string MedicationDetails { get; set; }
        public string DosageInstructions { get; set; }
    }
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public int? EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public Shipper Shipper { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public int? PrescriptionID { get; set; }
        public Prescription Prescription { get; set; }
        public string PaymentStatus { get; set; }
        public string OrderStatus { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
    }
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
    }
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; }
    }
    public class ShoppingCart
    {
        [Key]
        public int CartID { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
    public class CartItem
    {
        [Key]
        public int CartItemID { get; set; }
        public int CartID { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
    #endregion


    #region Previous Moel


 
    //public class Warehouse
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int WarehouseId { get; set; }
    //    public string? Name { get; set; }
    //    public string? Address { get; set; }
    //    public int? CompanyId { get; set; }
    //    public Company? Company { get; set; }
    //    public ICollection<Product>? Products { get; set; }
    //}

    //public class Product
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int ProductId { get; set; }
    //    public string? Name { get; set; }
    //    public int? WarehouseId { get; set; }
    //    public Warehouse? Warehouse { get; set; }
    //    public int? CategoryId { get; set; }
    //    public Category? Category { get; set; }
    //    public ICollection<OrderProduct>? OrderProducts { get; set; }
    //}

    //public class Category
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int CategoryId { get; set; }
    //    public string? Name { get; set; }
    //    public ICollection<Product>? Products { get; set; }
    //}

    //public class Order
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int OrderId { get; set; }
    //    public DateTime? OrderDate { get; set; }
    //    public ICollection<OrderProduct>? OrderProducts { get; set; }
    //}

    //public class OrderProduct
    //{
    //    public int? OrderId { get; set; }
    //    public Order? Order { get; set; }
    //    public int? ProductId { get; set; }
    //    public Product? Product { get; set; }
    //}


    #endregion
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
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Url { get; set; }
        public ICollection<SubMenu>? SubMenus { get; set; }
        public ICollection<MenuRole>? MenuRoles { get; set; }
    }

    public class SubMenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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

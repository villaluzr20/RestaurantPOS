using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public required string Email { get; set; }
    [Required]
    [MaxLength(50)]
    public required string PasswordHash { get; set; }
    [Required]
    [MaxLength(50)]
    public required string Role { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public required string CustomerName { get; set; }
    public required string CustomerAddress { get; set; }
    public required string CustomerPhone { get; set; }
    public required string CustomerEmail { get; set; }
    public required string OrderItems { get; set; }
    public required string OrderTotal { get; set; }
    public required string OrderStatus { get; set; }
}

public class MenuItem
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Price { get; set; }
    public required string Description { get; set; }
    public required string Category { get; set; }
    public required string Image { get; set; }

}
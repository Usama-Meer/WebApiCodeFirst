using System.ComponentModel.DataAnnotations;

namespace WebApiCodeFirst.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set;}
    [Required]
    [StringLength(100)]
    public string? FirstName { get; set;}

    [Required]
    [StringLength(100)]
    public string? LastName { get; set;}


    [Required]
    [StringLength(100)]
    public string? Email { get; set;}
}
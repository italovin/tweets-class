using System.ComponentModel.DataAnnotations;

namespace blazor_test.Models;

public class AccessKey{
    [Key]
    public int Id { get; set; }
    public string HashString { get; set; } = "";
}
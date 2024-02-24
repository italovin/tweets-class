using System.ComponentModel.DataAnnotations;

namespace blazor_test.Models.ORM;

public class AccessKey{
    [Key]
    public int Id { get; set; }
    public string HashString { get; set; } = "";
    public int Revoked { get; set; } = 0;
}
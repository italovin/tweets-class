using System.ComponentModel.DataAnnotations;

namespace Models.ORM;

public class AccessKey{
    [Key]
    public int Id { get; set; }
    public string HashString { get; set; } = "";
    public int Revoked { get; set; } = 0;
}
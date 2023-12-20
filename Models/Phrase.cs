using System.ComponentModel.DataAnnotations;

namespace blazor_test.Models;

public class Phrase {

    [Key]
    public int Id {get; private set;}
    public string Text { get; set; } = "";
    [MaxLength(5, ErrorMessage = "Cannot attribute more than 5 labelings")]
    public ICollection<Labeling> Labelings{ get; } = new List<Labeling>();
}
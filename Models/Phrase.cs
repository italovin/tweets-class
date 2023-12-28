using System.ComponentModel.DataAnnotations;

namespace blazor_test.Models;

public class Phrase {

    [Key]
    public int Id {get; private set;}
    public string Text { get; set; } = "";
    public ICollection<Labeling> Labelings{ get; } = new List<Labeling>();
}
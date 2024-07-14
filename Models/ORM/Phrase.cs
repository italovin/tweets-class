using System.ComponentModel.DataAnnotations;

namespace Models.ORM;

public class Phrase {

    [Key]
    public int Id {get; private set;}
    public string Text { get; set; } = "";
    public ICollection<Labeling> Labelings{ get; } = new List<Labeling>();
}
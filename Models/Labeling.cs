using System.ComponentModel.DataAnnotations;

namespace blazor_test.Models;

public class Labeling{
    [Key]
    public int Id { get; private set; }
    [Range(0, 2)]
    public int Label { get; set; }
    public int PhraseId { get; set; }
    public Phrase Phrase { get; set; } = null!;
}
using blazor_test.Features.Questions;

public class LabelInfo {
    public string Text { get; set; } = "Indefinido";
    public string RelatedColor { get; set; } = "#000000";
}

public static class LabelParser{

    public static LabelInfo ParseLabel(LabelEnum labelEnum){
        return labelEnum switch
        {
            LabelEnum.Negative => new LabelInfo { Text = "Negativo", RelatedColor = "#ff0000"},
            LabelEnum.Neutral => new LabelInfo { Text = "Neutro", RelatedColor = "#808080"},
            LabelEnum.Positive => new LabelInfo { Text = "Positivo", RelatedColor = "#00ff00"},
            _ => new LabelInfo { Text = "Indefinido", RelatedColor = "#000000"}
        };
    }

}